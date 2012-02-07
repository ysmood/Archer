/* Javascript Doc y.s.
*/

var Room = '';
var Offset = 0;
var Interval = 1000;
var UserName = '';
var CookieExpireTime = 3600 * 24 * 30;

var msg_icon_border_default_color;
var msg_icon_border_highlight_color = '#FA5A35';

// ***** Main *****

$(function()
	{
		Room = $('#msg_list').attr('room');
		Offset = $('#msg_list').attr('offset');
		Interval = $('#msg_list').attr('interval');
		UserName = ys.cookier.get('UserName');
		
		msg_icon_border_default_color = $('img.avatar:eq(0)').css('border-color');
		
		ys.cookier.set('Room', Room, CookieExpireTime);
		ys.cookier.set('Offset', Offset, CookieExpireTime);
		ys.cookier.set('Interval', Interval, CookieExpireTime);
	
		InitFrame();
		InitAnimation();
		InitEvent();
	}
);

// ***** Subfunction *****

function InitFrame()
{
	if($.browser.msie && $.browser.version < 8)
	{
		$('#top span.tool_strip').css({ float: 'none', marginLeft: 30 });
	}
	else
	{
		$('#top input:button, #msg_form input:submit, #manager_form input:submit, #login_form input:submit').button();
		$('#show_hide_msgbox').button();
		$('#msg_float_check').button({ icons: { primary: 'ui-icon-arrowstop-1-s' }, text: false });
		$('#msg_float_lock').button({ icons: { primary: 'ui-icon-pin-w' }, text: false }).click(
			function()
			{
				var option;
				if($(this).prop('checked'))
					option = { icons: { primary: 'ui-icon-pin-s' } };
				else
					option = { icons: { primary: 'ui-icon-pin-w' } };
				$(this).button('option', option);
			}
		);
	}
	
	mySettings['markupSet'][15]['call'] = function(){ location.href = '?r=help'; };
	
	$('#markItUp').markItUp(mySettings);
	
	$('input.UserName').val(UserName);
	$('#manager_form input:text').val(UserName);
	
	$('#manager_form').dialog(
		{
			modal: true,
			autoOpen: false,
			show: "puff",
			hide: "drop"
		}
	);
	
	$('#login_form').dialog(
		{
			modal: true,
			autoOpen: false,
			show: "puff",
			hide: "drop"
		}
	);
}

function InitEvent()
{
	$('#msg_form input:submit').click(send_msg);
	
	setInterval(get_msg, Interval);
	
	$('input.UserName')
		.focus(function(){ $(this).select(); })
		.change(function(){ if($(this).val() == '') $(this).val($(this)[0].title); });
		
	$('#msg_form textarea').one('focus', function() { $(this).select().css('color', '#222'); });
	
	$('#show_hide_msgbox').click(
		function()
		{
			if($('#msg_form').css('display') == 'none')
				$('#msg_form').fadeIn();
			else
				$('#msg_form').fadeOut();
		}
	);
		
	$('#room_manager').click(
		function()
		{
			if($('body').attr('login') == 'false')
			{
				$('#login_form').dialog('open');
				$('#login_form #UserName').val(UserName);
				
				setTimeout(function(){ $('#UserName').focus().select(); }, 1000);
			}
			else
				$('#manager_form').dialog('open');
		}
	);
	$('#manager_form input:submit').click(set_room_state);
	
	$('img.avatar').click(
		function()
		{
			if($('body').attr('login') == 'false')
			{
				$('#login_form').dialog('open');
				
				$('#login_form #UserName').val($(this).next().text());
				
				setTimeout(function(){ $('#UserName').focus().select(); }, 1000);
			}
			else
			{
				var selected = $(this).prop('selected');
				
				$('img.avatar').css('border-color', msg_icon_border_default_color).removeProp('selected');
				
				if(selected == true)
				{
					$(this).css('border-color', msg_icon_border_default_color);
					$('#msg_form input:submit').val('Send');
				}
				else
				{
					$(this).prop('selected', true).css('border-color', msg_icon_border_highlight_color);
					$('#markItUp').val($(this).nextAll('.Body').html());
					$('#msg_form input:submit').val('Change').attr('msg_id', $(this).parents('div.msg:eq(0)').attr('msg_id'));
				}
			}
		}
	);
	$('#login_form input:submit').click(login);
}

function InitAnimation()
{
	prettyPrint();
	$('.prettyprint').removeClass('prettyprint');
	$('.msg').hover(
		function(){ $(this).css('background', 'url(../img/high_light.png) repeat'); },
		function(){ $(this).css('background', 'none'); }
	);
	
	var bg_y = 0;
	var st_last = $(window).scrollTop();
	var msg_form = $('#msg_form');
	
	// Auto move the message editor
	$(window).scroll(
		function()
		{
			if($('#msg_float_lock').prop('checked')) return;
			
			var st = $(this).scrollTop();
			$('body').css('background-position-y', st - st_last < 0 ? bg_y += 1 : bg_y -= 1);
		
			if($('#msg_float_check').prop('checked'))
				msg_form.stop(true, false).animate({ top: $(this).height() + st - msg_form.height() - 50 });
			else
				msg_form.stop(true, false).animate({ top: st+ 50 });
				
			st_last = st;
		}
	);
	$('#msg_float_check').click(
		function()
		{
			var st = $(window).scrollTop();
			
			if($(this).prop('checked'))
				msg_form.stop(true, false).animate({ top: $(window).height() + st - msg_form.height() - 50 });
			else
				msg_form.stop(true, false).animate({ top: st + 50 });
		}
	);
}

function get_msg()
{
	var latest_msg = $('div.msg:eq(0)');
	var send_data =
	{
		ID: latest_msg.attr('msg_id'),
		Room: Room,
		tick: new Date().getTime()
	};
	$.getJSON(
		'get.php',
		send_data,
		function(data)
		{
			if(data == null) return;
			for(var i = 0; i < data.length; i++)
			{
				if($('div[msg_id=' + data[i]['ID'] + ']').length > 0) return;
			
				var msg_list = $('#msg_list').prepend('<div class="hr"></div>');
				var new_msg = latest_msg.clone(true, true).prependTo(msg_list).css('display', 'none');
				
				new_msg.attr('msg_id', data[i]['ID']);
				new_msg.find('.avatar').attr('src', 'http://www.gravatar.com/avatar/' + data[i]['UserName_MD5'] + '?s=32');
				new_msg.find('.UserName').text(data[i]['UserName']);
				new_msg.find('.DateTime').text(data[i]['DateTime'] + ' IP:' + data[i]['IP'] + ' ' + data[i]['HTTP_USER_AGENT']);
				new_msg.find('.Body').html(data[i]['Body']);
				
				new_msg.slideDown('slow');
				
				prettyPrint();
				$('.prettyprint').removeClass('prettyprint');
			}
		}
	);
}

function send_msg()
{
	var btn = $(this).prop('disabled', true);
	
	setTimeout(function(){ btn.prop('disabled', false); }, Interval);
	
	var send_data = 
	{
		Body: $('#markItUp').val(),
		UserName: $('#msg_form input:text').val(),
		Room: Room,
		ID: btn.val() == 'Send' ? '' : btn.attr('msg_id')
	};
	$.post('send.php',
		send_data,
		function(data)
		{
			switch(data)
			{
				case 'room_locked':
					alert('This room was locked, you can\'t send message to a locked room.');
					return;
					
				case 'server_failed':
					alert('An server error occured.');
					return;
					
				case 'auth_error':
					alert('You don\'t have the permission.');
					return;
					
				case 'msg_changed':
					$('div.msg[msg_id="' + send_data['ID'] + '"] .Body').html($('#markItUp').val());
					btn.val('Send');
					$('#markItUp').val('');
					$('img.avatar').css('border-color', msg_icon_border_default_color).removeProp('selected');
					break;
					
				case 'server_done':
					$('#markItUp').val('');
			}
			
		},
		'json'
	);
	
	ys.cookier.set('UserName', send_data['UserName'], CookieExpireTime);
}

function set_room_state()
{	
	var send_data = 
	{
		Room: Room,
		Locked: $('#manager_form #Locked').prop('checked'),
		Delete: $('#manager_form #Delete').prop('checked')
	};
	$.post(
		'manager.php',
		send_data,
		function(data)
		{
			switch(data)
			{
				case 'empty_error':
					alert('Please input valid values.');
					return;
					
				case 'server_failed':
					alert('An server error occured.');
					return;
					
				case 'auth_error':
					alert('You don\'t have the permission.');
					return;
					
				case 'server_done':
					alert('Operation done.');
					break;
			}
			
			location.href = location.href;
		}
	);
}

function login()
{
	UserName = $('#login_form #UserName').val();
	var send_data = 
	{
		Room: Room,
		UserName: UserName,
		Password: $('#login_form #Password').val(),
	};
	$.post(
		'../login.php',
		send_data,
		function(data)
		{
			switch(data)
			{
				case 'empty_error':
					alert('Please input valid values.');
					return;
					
				case 'server_failed':
					alert('An server error occured.');
					return;
					
				case 'auth_error':
					alert('User name or password error.');
					return;
					
				case 'server_done':
					$('body').attr('login', 'true');
					$('.tool_strip').append('<span>' + UserName + '</span> <a id="logout" href="../login.php?url=' + escape(location.href) + '">Logout</a>');
					ys.cookier.set('UserName', send_data['UserName'], CookieExpireTime);
					break;
			}
			$('#login_form').dialog('close');
			$('#login_form #Password').val('');
		}
	);
}