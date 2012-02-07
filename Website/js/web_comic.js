
/*
	Support Sites:
	
	http://www.xindm.cn/index.asp
	http://www.narutom.com/
*/

// ******** Config ********

var increase = 500;								// How many pages to load each time.
var auto_split_page = true;						// Auto split page when it is too wide.
var animation = true;							// Show animation effect or not.
var extension = ['.png', '.jpg'];				// Alternate image file extension.
var save_to = 'Comic\\';						// The default folder to save cache images.
var auto_save = true;							// Auto save image after loaded.

// ******** Interface ********

function save() // Save IE cached images.
{
	$('#btnSave').click();
}
function open() // Open the default comic folder.
{
	$('#open_folder').click();
}

// ******** Main ********

var total = $('select:eq(0) option').length;

var host = location.host.match(/.*(xindm|narutom)\..+/)[1];
switch(host)
{
	case 'xindm':
		if(location.href.indexOf('display.asp') == -1)
			RemoveAds();
		else
		{
			var info = $('span.dis_03:gt(2)');
			save_to += info[0].innerText.replace(/\[.+\]/, '') + '\\[' + info[1].innerText.replace(/( 正式版 new)|( 正式版)|( new)$/, '') + ']\\';
			LoadPage();
		}
		break;
		
	case 'narutom':
		if(location.href.match(/comic.+?html/) == null
			&& location.href.match(/manhua.+?html/) == null)
			RemoveAds();
		else
		{
			var info = $('.titlepos').html();
			save_to += info.substr(info.lastIndexOf('>') + 1).replace(/\s/, '') + '\\';
			
			LoadPage();
		}
		break;
}

$('a').removeAttr('target');
	
// ******** Subfunction ********

function RemoveAds()
{
	$('*').undelegate();	
	$('script, iframe').remove();
	
	switch(host)
	{
		case 'xindm':
			$('body > div').remove();
			if(location.href.indexOf('type.asp') == -1) $('body > table[height!=""]').remove();
			setTimeout(function(){ $('body > div, iframe').remove(); }, 100);
			break;
			
		case 'narutom':
			$('#searchBox, #topbanner, #footer, table.friends').remove();
			break;
	}
}

function LoadPage(sender)
{
/*
	Url Samples
	
	http://mh.xindm.cn/display.asp?id=53823&page=1
	../book2/w/World_E/Act_065/xindm_cn_000001.jpg
	../book/h/op/Act_629zs/2.png
	../book/D/DBDTL/01/000001.jpg
*/
	var current_url;
	switch(host)
	{
		case 'xindm':
			current_url = $('img[src*="book"]:last').attr('src');
			break;
			
		case 'narutom':
			if(sender == null)
				current_url = $('#showImg').attr('src');
			else
				current_url = $('img[src*="manhua"]:last').attr('src');
			break;
	}

	var longNumber = current_url.match(/((\d+).{4})$/)[2].length == 6;	
	var current_index = parseInt(current_url.match(/(\d{1,3}.{4})$/), 10) + (sender == null ? -1 : 0);
	var ex = current_url.slice(-4);
	var prefix = current_url.replace(/(\d+.{4})$/, "");
	
	$('html').html('');	
	var body = $('<body>');
	$('html').append(body);
	
	body.css(
		{
			background: '#eee',
			textAlign: 'center',
			paddingBottom: 200
		}
	);
	
	var indexTo = current_index + increase;
	indexTo = indexTo < total ? indexTo : total;
	
	for(var i = current_index; i < indexTo; i++)
	{
		var url;
		if(longNumber)
			url = prefix + pad(i, 3) + pad(i + 1, 3) + ex;
		else
			url = prefix + (i + 1) + ex;
		
		body.append(
			'<div class="img_frame" index="' + i + '" style="padding: 100px 0;">' +
			'	<div style="color: #666; font: bold 16px Arial; padding: 6px;">Page ' + pad(i + 1, 3) + ' / ' + pad(total, 3) + '</div>' +
			'	<img index="' + i + '" style="margin: 5px 0; border: 1px solid #ccc; cursor: move;" src="' + url + '"/>' +
			'</div>'
		);
	}
	
	InitAnimation();
	
	if(indexTo < total)
		body.append($('<button>Next Collection</button>').click(function(){ LoadPage(this); }));
	else
		body.append('<button disabled="disabled">No More</button>');
	
	if(!auto_save) body.append(
		$('<button id="btnSave">Save Image</button>').click(
			function()
			{
				var imgs = $('img');
				for(var i = 0; i < imgs.length; i++)
				{
					// Use Archer's COM
					external.save_cache(
						imgs[i].href, 
						save_to + imgs[i].href.slice(-7),
						true
					);
				}
				
				$('#open_folder').removeAttr('disabled');
				var result = $('<span style="display: none;">Saved in folder: "' + save_to + '"</span>');
				body.append(result);
				result.fadeIn('slow', function(){ result.fadeOut(5000); });
			}
		)
	);
	body.append(
		$('<button id="open_folder" disabled="disabled">Open Folder</button><br/>').click(
			function()
			{
				window.external.run(save_to);
			}
		)
	);
		
	$('button').css(
		{
			margin: 10,
			padding: 10
		}
	);
		
	$('img').error(
		function()
		{
			var current_ex = $(this).attr('src').slice(-4);
			if(current_ex == extension[0])
				$(this).attr('src', $(this).attr('src').slice(0, -4) + extension[1]);
			else
				$(this).attr('src', $(this).attr('src').slice(0, -4) + extension[0]);
		}
	);
	
	body.scrollTop(0);
	
	if(auto_save) AutoSave();
	
	InitUIControl();
}

function pad(num, n)
{
	var len = num.toString().length;
	while(len < n)
	{
		num = '0' + num;
		len++;
	}
	return num;
}

function AutoSave()
{
	var count = 0;
	var original_title = external.title;

	$('img').each(
		function()
		{
			$(this).load(
				function()
				{
 					external.save_cache(
						this.href, 
						save_to + this.href.slice(-7),
						true
					);
 					$('#open_folder').removeAttr('disabled');
					
					if(++count == total)
						external.title = '[ All Loaded ] ' + original_title;
					else
						external.title = '[ ' + count + ' Loaded ] ' + original_title;
				}
			);
		}
	);
}

function InitAnimation()
{
	if(!animation) return;
	
	$('img:gt(0)').css('opacity', 0);
	$('img:gt(0)').attr('hidden', '1');
	$(window).scroll(
		function()
		{
			var img = $('img[hidden]:eq(0)');
			
			if(img.length > 0
				&& img[0].offsetTop - $(window).scrollTop() < 200)
			{
				// Split page into two parts.
				if(auto_split_page
					&& img.attr('half') != 'true'
					&& img.width() > img.height())
				{
					var frame = $('.img_frame[index="' + img.attr('index') + '"]');
					frame.css(
						{
							width: img.width() / 2,
							overflow: 'hidden'
						}
					);
					frame.append(img.clone().attr('half', 'true'));
					img.css(
						{
							position: 'relative',
							left: -img.width() / 2
						}
					);
				}
				
				// Show page animation.
				img.animate({ opacity: 1 }, 500)
				img.removeAttr('hidden');
			}
		}
	);
}

function InitUIControl()
{
	document.onmousedown = function(){ return true; }
	document.oncontextmenu = function(){ return true; }
	
	var pos;
	var isDraging = false;
	
	var body = $('body');
	body.mousedown(
		function(e)
		{
			if(e.target.nodeName.toLowerCase() == 'body'
				|| e.which != '1')
				return;

			pos = e;
			isDraging = true;
		}
	);
	
	body.mousemove(
		function(e)
		{
			if(!isDraging
				|| e.target.nodeName.toLowerCase() == 'body')
				return;
			
			var wnd = $(window);
			wnd.scrollTop(wnd.scrollTop() + pos.pageY - e.pageY);
			wnd.scrollLeft(wnd.scrollLeft() + pos.pageX - e.pageX);
				
			e.preventDefault();
		}
	);
	
	body.mouseup(
		function(e)
		{
			isDraging = false;
		}
	);
}