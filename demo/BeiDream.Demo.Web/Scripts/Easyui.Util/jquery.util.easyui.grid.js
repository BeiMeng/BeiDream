(function ($) {
    //grid的操作
    $.easyui.grid = (function () {
        return {
            //获取选择行的id集合
            getIds: function (rows) {
                if (!rows)
                    return "";
                var ids = "";
                $(rows).each(function (i, row) {
                    ids += i === 0 ? row.Id : "," + row.Id;
                });
                return ids;
            },
            //获取选择行
            getRows: function (gridId) {
                var grid = $.easyui.getGrid(gridId);
                var result = grid.datagrid("getChecked");
                if (!$.isEmptyArray(result))
                    return result;
                var row = grid.datagrid('getSelected');
                if (!row)
                    return result;
                result.push(row);
                return result;
            },
            //grid查询
            Query: function (formId, gridId) {
                ///	<summary>
                ///	查询
                ///	</summary>
                ///	<param name="formId" type="String">
                ///	查询表单Id
                ///	</param>
                ///	<param name="gridId" type="String">
                ///	表格Id
                ///	</param>
                $.easyui.getGrid(gridId).datagrid({
                    pageNumber: 1,
                    queryParams: $.easyui.getQueryForm(formId).serializeJson()
                });
            },
            //grid选中的行删除
            DeleteByUrl: function (url, callback, gridId) {
                ///	<summary>
                ///	删除记录
                ///	</summary>
                ///	<param name="url" type="String">
                ///	删除对应的后台url
                ///	</param>
                ///	<param name="callback" type="Function">
                ///	成功回调函数
                ///	</param>
                ///	<param name="gridId" type="String">
                ///	表格Id
                ///	</param>
                url = url || $.easyui.deleteUrl;
                if (!url) {
                    $.easyui.message.warn("删除Url未设置，请联系管理员");
                    return;
                }
                var grid = $.easyui.getGrid(gridId);
                var rows = $.easyui.grid.getRows(gridId);
                if ($.isEmptyArray(rows)) {
                    $.easyui.message.warn($.easyui.deleteNotSelectedMessage);
                    return;
                }
                $.easyui.message.confirm($.easyui.deleteConfirmMessage, ajaxDelete);
                //发送删除请求
                function ajaxDelete() {
                    var ids = $.easyui.grid.getIds(rows);
                    deleteajax(ids);
                }
                //发送删除请求
                function deleteajax(ids) {
                    url = url || $.easyui.deleteUrl;
                    var param = { ids: ids, __RequestVerificationToken: $.getAntiForgeryToken() };
                    $.easyui.ajax(url, param, function (result) {
                        if (callback)
                            callback(result);
                        else
                            deleteSuccess(result);
                    });
                };

                //删除成功回调函数
                function deleteSuccess(result) {
                    gridId.toLowerCase() === "treegrid" ? grid.treegrid("reload") : grid.datagrid("reload");
                    $.easyui.showMessage(result);
                }
            },
            //提交选中的Id
            submitCheckedIds: function (gridId, url, param, callback, fnRefresh) {
                var grid = $.easyui.getGrid(gridId);
                var rows = grid.datagrid("getChecked");
                if (rows.length === 0) {
                    $.easyui.message.warn($.easyui.notCheckedMessage);
                    return;
                }
                ajax();

                //发送请求
                function ajax() {
                    var ids = $.easyui.grid.getIds(rows);
                    param = $.extend({ ids: ids, __RequestVerificationToken: $.getAntiForgeryToken() }, param || {});
                    $.easyui.ajax(url, param, ajaxCallback);

                    //回调
                    function ajaxCallback(result) {
                        $.easyui.showMessage(result);
                        if (result.Code !== $.easyui.state.ok)
                            return;
                        if (fnRefresh)
                            fnRefresh(result);
                        if (callback)
                            callback(result);
                    }
                }
            }
        }
    })();
})(jQuery);