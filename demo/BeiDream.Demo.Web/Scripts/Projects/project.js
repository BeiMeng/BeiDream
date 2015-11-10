//主界面操作
(function ($) {
    $.project = (function () {
        return {
            //添加我的桌面选项卡
            addDesktopTab: function () {
                $.project.addToMainTabs("我的桌面", "/Desktop/Index", "icon-help", false);
            },
            //单击左侧菜单树
            clickMainMenuNode: function (node) {
                if (!node.attributes)
                    return;
                if (!node.attributes.url)
                    return;
                $.project.addToMainTabs(node.text, node.attributes.url, node.iconCls, true);
            },
            //添加主界面选项卡
            addToMainTabs: function (txt, url, icon, closable) {
                $.easyui.addIframeToTabs("divMainTabs", txt, url, icon, closable);
                var tabs = $('#divMainTabs');
            }
        };
    })();
})(jQuery);

$(function () {
    //主界面初始化操作
    $.project.addDesktopTab();
});