
$(window).ready(
	function()
	{
		var backgroundPositionX = 0;
		setInterval(
			function()
			{
				$('#main').css({ backgroundPosition:backgroundPositionX++ + 'px 0' });
			},
			50
		);
			
		SetPopup('.archer','Archer Project',{ position:'left' });
		SetPopup('.share','Script Store',{ position:'left' });
		SetPopup('.pebble','Pebble Instant Messaging',{ position:'left' });
		SetPopup('.download','Download the Latest Version of Archer',{ position:'left' });
		SetPopup('.sign_up','For More Services, Get an Archer Account',{ position:'left' });
		
		ProjectPageNavi('.archer', 'http://code.google.com/p/ys-archer/');
		ProjectPageNavi('.share', 's/');
		ProjectPageNavi('.pebble', 'p/');
		ProjectPageNavi('.sign_up', 'r/');
		ProjectPageNavi('#register', 'r/');
		
		$.getJSON('deploy.php?r=a',
			function(data)
			{
				$('.download').click(
					function()
					{
						location.href = data['url'];
					}
				);
			}
		);
			
		$('#main').css('display','none');
		$('#main').fadeIn(
			'slow',
			function()
			{
				$('.archer, .share, .pebble, .download, .sign_up, #underConstruction').fadeIn('slow');
			}
		);
		
		$('.icon').hover(
			function(){ $(this).css({ background:'url(img/icon_bg-64.png)' }); },
			function(){ $(this).css({ background:'none' }); }
		);

	}
);

function ProjectPageNavi(name, url)
{
	$(name).click(
		function()
		{
			$('.icon').fadeOut('slow',
				function()
				{
					$('#main').fadeOut('slow',
						function()
						{
							location.href = url;
						}
					);
				}
			);
		}
	);
}
