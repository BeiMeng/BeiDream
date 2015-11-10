(function ($) {
    //form表单操作
    $.easyui.form = (function () {
        return {
            submit: function (fnBefore, fnSuccess, formId) {
                ///	<summary>
                ///	提交更新表单
                ///	</summary>
                ///	<param name="fnBefore" type="Function">
                ///	提交前操作
                ///	</param>
                ///	<param name="fnSuccess" type="Function">
                ///	成功操作
                ///	</param>
                ///	<param name="formId" type="String">
                ///	表单Id
                ///	</param>
                var form = $.easyui.getForm(formId);
                if (!validate())
                    return;
                if (!submitBefore())
                    return;
                ajaxSubmit();
                //验证表单
                function validate() {
                    return form.form('validate');
                }
                //提交前操作
                function submitBefore() {
                    if (!fnBefore)
                        return true;
                    return fnBefore(form);
                }
                //提交
                function ajaxSubmit() {
                    var message = form.attr("confirm");
                    if (message)
                        $.easyui.message.confirm(message, saveAjax);
                    else
                        saveAjax();
                }
                //发送请求
                function saveAjax() {
                    //表单里自动添加了防伪标识
                    $.easyui.ajax(form.attr("action"), form.serializeArray(), ajaxCallback);

                    //回调
                    function ajaxCallback(result) {
                        $.easyui.showMessage(result);
                        if (result.Code !== $.easyui.state.ok)
                            return;
                        if (fnSuccess)
                            fnSuccess(result, getGridId());
                        else
                            submitSuccess();
                    }

                    //成功回调函数
                    function submitSuccess() {
                        var grid = $.easyui.getById(getGridId());
                        if (grid)
                            getGridId().toLowerCase() === "treegrid" ? grid.treegrid("reload") : grid.datagrid("reload");
                        $.easyui.closeDialog();
                    }
                };

                //获取表格编号
                function getGridId() {
                    //使用时，注意Form上的属性跟grid上的Id保持一至
                    return form.attr("gridId") || $.easyui.gridId;
                }
            }
        };
    })();
})(jQuery);