(function ($) {
    //grid的操作
    $.easyui.treegrid = (function() {
        return {
            Query: function (formId, gridId, fnQueryBefore) {
                ///	<summary>
                ///	刷新
                ///	</summary>
                ///	<param name="formId" type="String">
                ///	查询表单Id
                ///	</param>
                ///	<param name="gridId" type="String">
                ///	表格Id
                ///	</param>
                ///	<param name="fnQueryBefore" type="Function">
                ///	查询前操作
                ///	</param>
                var param = $.easyui.getQueryForm(formId).serializeJson();
                if (fnQueryBefore)
                    fnQueryBefore(param);
                $.easyui.getGrid(gridId).treegrid({
                    pageNumber: 1,
                    queryParams: param
                });
            }
            ////获取选择行
            //getRows: function (gridId) {
            //    var grid = $.easyui.getGrid(gridId);
            //    var result = grid.treegrid("getChecked");
            //    if (!$.isEmptyArray(result))
            //        return result;
            //    var row = grid.treegrid('getSelected');
            //    if (!row)
            //        return result;
            //    result.push(row);
            //    return result;
            //},
            ////grid选中的行删除
            //DeleteByUrl: function (url, callback, gridId) {
            //    var rows = $.easyui.treegrid.getRows(gridId);
            //    $.easyui.grid.Delete(url, callback, gridId, rows);
            //}
        }
    })();
})(jQuery);