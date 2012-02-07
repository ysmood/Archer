/*	y.s. JavaScript Framework
	Some of the object are base on jQquery, so link this fx after jQquery.
*/

this.ys = new ys();

function ys()
{
	
	this.fullInfo = "y.s. JavaScript Framework 0.0.1";
	this.version = this.fullInfo.split(" ")[3];
	
	this.browser = new browser();
	this.pcTester = new pcTester();
	this.animer = new animer();
	this.cookier = new cookier();

/* Browser Infomation */
	
	function browser()
	{
		var core, version, fullInfo;
				
		if($.browser.msie)
			core = "IE";
		else if($.browser.mozilla)
			core = "Firefox";
		else if($.browser.opera)
			core = "Opera";
		else if($.browser.safari)
			core = "Safari";
		else
			core = "Unknown";
		
		version = $.browser.version;
		fullInfo = core + " " + version;
		
		this.core = core;
		this.version = version;
		this.fullInfo = fullInfo;
	}

/* Performance Tester */
	function pcTester()
	{
		var last;
		
		this.fire = fire;
		this.last = last;
		
		function fire(duration)
		{
			var i = 0;
			var timestamp = new Date().getTime() + duration;
			while(timestamp - new Date().getTime() > 0)
			{
				// This task depends on both the page content and client performance.
				var task = document.getElementsByTagName("div");
				i++;
			}
			last = i;
			return i;
		}
	}

/* jQquery Animation Manager */
	function animer()
	{
		this.zoomToggle = zoomToggle;
		this.slideShowQueue = slideShowQueue;
		this.slideDownQueue = slideDownQueue;
		
		function zoomToggle(
			target,
			opacityFrom,
			opacityTo,
			ratioFrom,
			ratioTo,
			timespan,
			complete)
		{
			var w = $(target).width();
			var h = $(target).height();

			if(w == 0 || h == 0) return;
			$(target).css(
				{
					opacity: opacityFrom,
					width: w * ratioFrom,
					height: h * ratioFrom
				}
			);
			$(target).animate(
				{
					opacity: opacityTo,
					width: w * ratioTo,
					height: h * ratioTo
				},
				timespan,
				complete
			);
		}
		
		function slideShowQueue() // To make the device doesn't support JavaScript can see the contents.
		{
			for(var i = 0; i < arguments.length; i++)
			{
				$(arguments[i]).css("display", "none");
			}		
			slideDownQueue(arguments, 0);
		}
		
		function slideDownQueue(q, i)
		{
			if(i < q.length)
				$(q[i]).slideDown("slow",
					function()
					{
						slideDownQueue(q, i+1);
					}
				);
			else
				return;
		}
	}
	
/* Cookie Manager */

	function cookier()
	{
		this.set = set;
		this.get = get;
		this.del = del;
		
		// Duration unit is second.
		function set(name, value, duration)
		{
			var date = new Date();
			if(duration == null)
				duration = 0;
			date.setTime(date.getTime() + duration * 1000);
			document.cookie = name + "="+ escape(value) + ";expires=" + date.toGMTString();
		}
		
		function get(name)
		{
			var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
			if(arr != null)
				return unescape(arr[2]);
			else
				return;
		}
		
		function del(name)
		{
			var date = new Date();
			date.setTime(0);
			var value = get(name);
			if(value != null)
				document.cookie = name + "=" + value + ";expires=" + date.toGMTString();
		}
	}
}