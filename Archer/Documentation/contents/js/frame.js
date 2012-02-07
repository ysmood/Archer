/* JavaScript Doc Version 0.1 y.s. */

function frame()
{
	$('#header').prepend(
		'<img style="float: left; margin: 4px 4px;" src="img/archer16.png"/>' + 
		'<a href="0-Archer.html">Archer Documentation</a> &gt;&gt; '
	);
	$('#footer').append(
		'May 2011 y.s.<br>' +
		'E-mail: archer_server@sina.com'
	);

	var index = location.href.substr(location.href.lastIndexOf('/') + 1,1);
	$('h1').prepend(index + '.');
	$('h2').each(
		function (i)
		{
		    $(this).prepend(index + '.' + i + '.');
		}
	);
}