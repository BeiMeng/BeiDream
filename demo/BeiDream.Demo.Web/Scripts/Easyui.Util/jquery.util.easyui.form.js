(function ($) {

    //grid的列的数据格式化
    $.easyui.form = (function () {
        return {
            //格式化布尔值
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
            }
        };
    })();
})(jQuery);