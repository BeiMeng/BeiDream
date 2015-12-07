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
        }
    })();
})(jQuery);