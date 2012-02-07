/* JavaScript Doc y.s. */

$(window).ready(
	function()
	{
		CheckArcher();
		InitFrame();
		InitAnimation();
		InitEvent();
	}
);

function CheckArcher()
{
	if(external.archer == null)
	{
		alert("This is not in Archer's browser, some functions may not work.");
	}
}

function InitFrame()
{
	$('#bottom').prepend($('#top').html());

	$('.arrow').corner('bevel 6px');
	
	$('.prettyprint').corner('bevel 3px');
	
	$('.navigator span *').css(
		{
			verticalAlign: 'middle'
		}
	);
	
}

function InitAnimation()
{	
	$('#main, .arrow').fadeIn();
	
	$('.arrow').hover(
		function(){ $(this).css('background-color', '#B1D4FF'); },
		function(){ $(this).css('background-color', '#98C6FF'); }
	);
		
	SetPopup(".btn_add","Add arrow to local storage", { position:"left" });
	SetPopup(".btn_delete","Delete an arrow in Script Store", { position:"left" });
}

function InitEvent()
{
	$('.cmd .name').each(
		function()
		{
			var value = $(this).next();
			var fold_indicator = $('<span>');
			$(this).prepend(fold_indicator);
			if(value[0].scrollHeight > 50)
			{
				fold_indicator.text('+');
				$(this).css('cursor', 'pointer');
				$(this).click(
					function()
					{
						value.animate(
							{
								height: value.height() == 40 ? value[0].scrollHeight : 40
							}
						);
						if(fold_indicator.text() == '+')
							fold_indicator.text('-');
						else
							fold_indicator.text('+');
					}
				);
			}
		}
	);
	
	var getting = false;
	$('.btn_add').click(
		function()
		{
			if(getting)
			{
				alert('Loading data, please wait...');
				return;
			}
			else
				getting = true;
			
			var button = $(this);
			$.getJSON(
				'get.php?r=arrow&guid=' + $(this).parents().attr('guid'),
				function(data)
				{
					getting = false;
					
					if(external.add_arrow(
							data[0]['Name'],
							data[0]['Cmd'],
							data[0]['Arg'],
							data[0]['Tag'],
							data[0]['HotKey'],
							data[0]['Enabled'],
							data[0]['Timestamp'],
							data[0]['GUID']
						)
					)
					{
						external.refresh_archer();
						button.css('opacity', 0.3);
					}
				}
			);
		}
	);
	
	$('.btn_delete').click(
		function()
		{
			external.del_arrow(
				$(this).parents().attr('guid'),
				$(this).parents('div:eq(0)').find('.upload_date .value').text()
			);
			
			$(this).parents('div:eq(0)').slideUp('slow', function(){ $(this).remove(); });
		}
	);
	
	$('.goto_page input').change(
		function()
		{
			$(this).next().attr('href', '?page=' + $(this).val() + '&search=' + escape($('.search input').val()));
		}
	);
	
	$('.search input').change(
		function()
		{
			$(this).next().attr('href', '?page=1&search=' + escape($(this).val()));
			$('#center').unhighlight().highlight($(this).val());
		}
	);
	
	$('#center').highlight($('.search input').val());
}