MetroUITemplate.MvcWrapper
==========================

ASP.NET MVC wrapper for MetroUI Template

So... odd as it sounds, there are very few Modern UI (Metro) packages out there for web applications.  I have found one to be full featured from <a href="http://metro-webdesign.info" target="_blank">metro-webdesign.info</a> called Metro UI Template.  The guy has done a fantastic job and I highly recommend donating and getting the full version.

Metro UI Template was written for a PHP, I'm a .NET guy.  So we had a problem.  So what does a good dev do?  Solve the problem.

Create some server wrappers for the client side JavaScript and move forward with the project.  And so that's what we've done.

Lets be clear, this is not fully fleshed out and was used to prove some concepts.  Hopefully others will jump in and help with these wrappers and flesh them out even more.  Read the code!

Also note that what I'm posting is based on their "lite" version, so you can try it before you upgrade to his full product.  But this means it does not have all the available tile types, but enough for you to get a really good feel of creating a tile based web app.  Off we go!
<ol>
	<li>Download Metro UI Template, <a href="http://metro-webdesign.info/#!/download" target="_blank">http://metro-webdesign.info/#!/download</a></li>
	<li>Download/view my wrapper at <a href="https://github.com/dwm9100b" target="_blank">https://github.com/dwm9100b</a></li>
	<li>Right click on the downloaded files, go to properties, and unblock</li>
	<li>Extract the zips</li>
	<li>Create a new ASP.NET MVC application, Razor Engine
<ul>
	<li>Name the project:  MyMetroApp</li>
</ul>
</li>
	<li>Create new folder in the root of your project
<ul>
	<li>Name the folder: MetroUI</li>
</ul>
</li>
	<li>Drop (add) the following folders from the extracted V4_lite folder into the MetroUI folder
<ul>
	<li>css</li>
	<li>img</li>
	<li>js</li>
	<li>plugins</li>
	<li>themes</li>
</ul>
</li>
	<li>Add the following folder from MetroUITemplate.MvcWrapper-master folder into the root of your project
<ul>
	<li>MetroUIMvc</li>
</ul>
</li>
	<li>If you did not name your project "MyMetroApp", you need to change the namespace in the following files
<ul>
	<li>Enums
<ul>
	<li>TileSize.cs</li>
	<li>TileType.cs</li>
</ul>
</li>
	<li>MetroColumn.cs</li>
	<li>MetroRow.cs</li>
	<li>MetroScreen.cs</li>
	<li>MetroTile.cs</li>
</ul>
</li>
	<li>Build your solution to see if we missed anything so far</li>
	<li>Replace the following in your project from the MetroUITemplate.MvcWrapper-master folder
<ul>
	<li>Views/Home/Index.cshtml</li>
	<li>Views/Shared/_Layout.cshtml</li>
	<li>Controllers/HomeController.cs</li>
</ul>
</li>
	<li>Buid your solution, F5 to run your app</li>
</ol>
Mobile (responsive) design is not available in the lite version, Upgrade to the full version and you will get some really nice tile repositioning based on device, all the way down to mobile phones.

For the record, I have no association with metro-webdesign.  I found their product to be superior and created a solution for my needs and wanted to share with others how to integrate his project with ASP.NET MVC.
