/* Javascript Doc */

var num_width = 61;             // number width.
var current;                    // current clicked number
var previous;                   // previous clicked number
var selected_offset_x = -42;    
var selected_offset_y = -8;    
var tmrWaiting;
var tmr_flash;
var converse_interval = 1000;
var player;
var current_player;
var locked;
var state_text = ['your turn', 'waiting for your partner...', 'you win!', 'you lose!'];

/*********************** Main *************************/

    $(function()
        {
            // init numbers to display the default value
            $('.clicked').css('opacity', 0);
            
            set_num('.num', 1);
            
            player = parseInt($('#display').attr('player'));
            
            if(player == 0)
            {
                current = $('#num_0');
                previous = current;
            }
            else
            {
                current = $('#num_2');
                previous = current;
                
                $('#selected').css('top', 212);
                
                act();
            }
            
            
            // init basic events
            $('.num').click(num_click);
            flash();
        }
    );

/******************* Subfunction **********************/

    function num_click()
    {
        current = $(this);
        
        current.find('.clicked').animate({opacity: 1}).animate({opacity: 0});
        
        // game logic
        if(previous.attr('mark') != current.attr('mark')
            && current.attr('mark') != player
            && !locked)
        {
            var sum = get_num(previous) + get_num(current);
            
            set_num(previous, sum % 10);
            
            act();
        }
        else
        {
            $('#selected').animate(
                {
                    left: parseInt(current.css('left')) + selected_offset_x,
                    top: parseInt(current.css('top')) + selected_offset_y
                },
                'fast',
                flash
            );
            previous = current;
        }
        
    }
    
    function flash()
    {
        clearInterval(tmr_flash);
        
        var e = current.find('.clicked');
        tmr_flash = setInterval(
            function()
            {
                e.animate({opacity: 1}, 1000).animate({opacity: 0}, 1000);
            },
            2000
        );
        
    }
    
    function set_num(num, value)
    {
        $(num)
            .animate({ backgroundPosition: -value * num_width }, 'fast', check_winner)
            .attr('val', value);
    }
    
    function get_num(num)
    {
        return parseInt($(num).attr('val'));
    }
    
    function act()
    {
        current_player = (player + 1) % 2;
        locked = true;
        $('#state').text(state_text[1]);
        
        var converse_data = {};
        converse_data['p'] = current_player;
        converse_data['c'] = new Date().getTime();            // fix browser cache problem
        for(var i = 0; i < 4; i++)
            converse_data['num_' + i] = get_num('#num_' + i);
        
        $.getJSON(
            'server.php',
            converse_data,
            function(data)
            {
                tmrWaiting = setInterval(converse, converse_interval);
            }
        );
    }
    
    function converse()
    {
        $.getJSON(
            'server.php?c=' + new Date().getTime(),
            function(data)
            {
                if(data['p'] == player)
                {
                    for(var i = 0; i < 4; i++)
                        set_num('#num_' + i, data['num_' + i]);
                    
                    $('#state').text(state_text[0]);
                    clearInterval(tmrWaiting);
                    
                    locked = false;
                }
            }
        );
    }
    
    function check_winner()
    {
        if(get_num('#num_0') == 9
            && get_num('#num_1') == 9)
            $('#state').text(state_text[player + 2]);
        if(get_num('#num_2') == 9
            && get_num('#num_3') == 9)
            $('#state').text(state_text[(player + 1) % 2 + 2]);
    }
