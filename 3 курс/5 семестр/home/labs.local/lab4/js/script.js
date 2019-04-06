function buildMenu(parentid, menuData, level)
{
	var menuScript = '';
	var subMenu = '';
	for (var i = 0; i < menuData.length; i++) {
		var menuItem = menuData[i];
		if (menuItem.pageparentid == parentid)
		{
			menuScript += '<li><a href="#" title="'+menuItem.pageheader+'">'+menuItem.pageheader+'</a>';
			subMenu = buildMenu(menuItem.pageid, menuData, (level + 1));
			if(subMenu != '')
			{
				menuScript += '<ul'+
					((level==1)?' class="mainmenuin1">':(level>=2)?' class="mainmenuin2">':'>')+
					subMenu+
					'</ul>';
			}
			menuScript += '</li>'
		}
	}
	return menuScript;
}

function addMenuText(MenuArr)
{
	var menuData = JSON.parse(MenuArr);
	var container = document.getElementById("mainmenu");
	container.innerHTML = buildMenu(null, menuData, 1);
}
