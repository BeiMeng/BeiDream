(function ($) {
    //更新表单Id
    $.easyui.formId = "form";
    //查询表单Id
    $.easyui.queryFormId = "formQuery";
    //表格Id
    $.easyui.gridId = "grid";
    //树型表格Id
    $.easyui.treeGridId = "treeGrid";
    //树Id
    $.easyui.treeId = "tree";
    //面板按钮div Id
    $.easyui.buttonsDivId = "dialogButtons";
    //更新按钮Id
    $.easyui.btnEditId = "btnEdit";
    //查看按钮Id
    $.easyui.btnLookId = "btnLook";
    //表格右键菜单Id
    $.easyui.gridMenuId = "menuGrid";
    //树右键菜单Id
    $.easyui.treeMenuId = "menuTree";
    //更新树节点按钮Id
    $.easyui.btnEditTreeId = "btnEditTree";
    //删除树节点按钮Id
    $.easyui.btnDeleteTreeId = "btnDeleteTree";
    //删除Url
    $.easyui.deleteUrl = "";
    //保存Url
    $.easyui.saveUrl = "";
    //提交选中Id的Url
    $.easyui.submitIdsUrl = "";
    //新行模板
    $.easyui.newRow = {};
    //新行模板url
    $.easyui.newRowUrl = "";
    //删除树Url
    $.easyui.deleteUrlByTree = "";
    //提交树选中Id的Url
    $.easyui.submitIdsUrlByTree = "";

    //获取更新表单jQuery对象
    $.easyui.getForm = function (formId) {
        formId = formId || $.easyui.formId;
        return $("#" + formId);
    }

    //获取查询表单jQuery对象
    $.easyui.getQueryForm = function (formId) {
        formId = formId || $.easyui.queryFormId;
        return $("#" + formId);
    }

    //获取表格jQuery对象
    $.easyui.getGrid = function (gridId) {
        gridId = gridId || $.easyui.gridId;
        return $("#" + gridId);
    }

    //获取树jQuery对象
    $.easyui.getTree = function (treeId) {
        treeId = treeId || $.easyui.treeId;
        return $("#" + treeId);
    }

    //获取表格右键菜单jQuery对象
    $.easyui.getGridMenu = function (menuId) {
        menuId = menuId || $.easyui.gridMenuId;
        return $("#" + menuId);
    }

    //获取树右键菜单jQuery对象
    $.easyui.getTreeMenu = function (menuId) {
        menuId = menuId || $.easyui.treeMenuId;
        return $("#" + menuId);
    }

    //获取更新按钮jQuery对象
    $.easyui.getEditButton = function (btnId) {
        btnId = btnId || $.easyui.btnEditId;
        return $("#" + btnId);
    }

    //状态:ok为成功,fail为失败
    $.easyui.state = {
        ok: 1,
        fail:3
    };
    //提示消息
    $.easyui.editNotSelectedMessage = "请选择待编辑的记录";
    $.easyui.lookNotSelectedMessage = "请选择待查看的记录";
    $.easyui.deleteNotSelectedMessage = "请选择待删除的记录";
    $.easyui.deleteConfirmMessage = "您确定删除选中的记录吗?";
    $.easyui.saveNotChangeMessage = "没有需要保存的记录";
    $.easyui.notCheckedMessage = "请勾选需要操作的记录";
    $.easyui.moveUpNotSelectedMessage = "请选择需要上移的记录";
    $.easyui.moveDownNotSelectedMessage = "请选择需要下移的记录";
    $.easyui.editTreeNotSelectedMessage = "请选择待编辑的树节点";
    $.easyui.treeNotCheckedMessage = "请勾选需要操作的树节点";
})(jQuery);