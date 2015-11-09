(function ($) {
    //index页面对应的jQuery对象
    var $parent = parent.$;
    //弹出窗口标识
    var dialogsKey = "dialogs";
    //全局数据编号(在Home的Index页面有个全局模态窗口数据保存标签)
    var dataKey = "#div_index_data";

    //获取弹出窗口数据集合
    function getDialogs() {
        return $.easyui.getArray(dialogsKey);
    }

    //获取当前弹出窗口数据
    function getCurrentDialog() {
        return $.easyui.getItem(dialogsKey);
    }

    //获取当前弹出窗口Id
    function getCurrentDialogId() {
        return getCurrentDialog().id;
    }

    //添加弹出窗口数据,包括弹出窗口Id和jQuery对象
    function addDialog(id) {
        $.easyui.addItem(dialogsKey, { id: id, $this: $ });
    }

    //移除当前弹出窗口数据
    function removeCurrentDialog() {
        var dialogs = getDialogs();
        dialogs.pop();
    }
    //easyui的操作扩展
    $.easyui = (function () {
        return {
            //添加全局数据，存储到index页面
            addData: function (key, data) {
                $parent(dataKey).data(key, data);
            },
            //添加全局数据，将项添加到数组中
            addItem: function (key, item) {
                var list = $.easyui.getArray(key);
                list.push(item);
                $.easyui.addData(key, list);
            },
            //获取数据
            getData: function (key) {
                return $parent(dataKey).data(key);
            },
            //获取数组
            getArray: function (key) {
                var data = $.easyui.getData(key);
                data = data || [];
                if ($.isEmptyArray(data))
                    return [];
                return data;
            },
            //获取项
            getItem: function (key) {
                var list = $.easyui.getArray(key);
                if (list.length === 0)
                    return {};
                return list[list.length - 1];
            },
            //获取当前$
            getCurrent$: function () {
                var dialog = getCurrentDialog();
                if (!dialog)
                    return $;
                if (!dialog.$this)
                    return $;
                return dialog.$this;
            },
            //通过Id获取jQuery对象
            getById: function (id) {
                var current$ = $.easyui.getCurrent$();
                return current$("#" + id);
            },
            Showdialog: function (options) {
                ///	<summary>
                ///	弹出模态窗，解决在Iframe中无法全屏遮罩,
                /// 注意:仅支持url弹窗
                ///	</summary>
                ///	<param name="options" type="Object">
                ///  1. title:标题
                ///  2. url:网址
                ///  3. buttons:显示在窗口底部的按钮区域div的id
                ///  4. icon:图标class
                ///  5. width:宽度
                ///  6. height:高度
                ///  7. onInit:初始化事件，返回false跳出执行
                ///	</param>
                initOptions();
                if (!options.onInit(options))
                    return;
                var dialog = createDialow();
                show();
                addDialog(options.id);

                //初始化参数
                function initOptions() {
                    options = $.extend({
                        id: $.newGuid(""),
                        title: '',
                        url: '',
                        icon: '',
                        width: 800,
                        height: 360,
                        closed: false,
                        maximizable: true,
                        resizable: true,
                        cache: false,
                        modal: true,
                        buttons: $.easyui.buttonsDivId,
                        onInit: function () {
                            return true;
                        },
                        closeCallback: function () { }
                    }, options || {});
                }

                //创建窗口div
                function createDialow() {
                    return $parent("<div id='" + options.id + "'></div>").appendTo('body');
                }

                //弹出窗口
                function show() {
                    dialog.dialog({
                        title: options.title,
                        href: options.url,
                        width: options.dialogWidth || options.width,
                        height: options.dialogHeight || options.height,
                        closed: options.closed,
                        maximizable: options.maximizable,
                        resizable: options.resizable,
                        cache: options.cache,
                        modal: options.modal,
                        iconCls: options.icon,
                        onLoad: function () {
                            var win = $parent("#" + options.id).window("window");
                            $parent("#" + options.buttons).addClass("dialog-button").appendTo(win);
                        },
                        onClose: function () {
                            if (options.closeCallback)
                                options.closeCallback();
                            $parent("#" + getCurrentDialogId()).dialog('destroy');
                            removeCurrentDialog();
                        }
                    });
                }
            },
            //关闭弹出窗口
            closeDialog: function () {
                var dialogId = getCurrentDialogId();
                if (!dialogId)
                    return;
                $parent('#' + dialogId).dialog('close');
            },
            addIframeToTabs: function (tabsId, title, url, icon, closable) {
                ///	<summary>
                ///	为tabs添加iframe选项卡
                ///	</summary>
                ///	<param name="tabsId" type="String">
                ///	选项卡Id
                ///	</param>
                ///	<param name="title" type="String">
                ///	标题，可以重复
                ///	</param>
                ///	<param name="url" type="String">
                ///	网址,必须唯一
                ///	</param>
                ///	<param name="icon" type="String">
                ///	图标class
                ///	</param>
                ///	<param name="closable" type="Bool">
                ///	是否允许关闭
                ///	</param>
                if (!title && !url)
                    return;
                var tabs = $('#' + tabsId);
                var index;
                var iframe = null;
                if (exists())
                    refresh();
                else
                    createTab();
                selectTab();

                //判断选项卡是否存在,根据url进行判断
                function exists() {
                    var allTabs = tabs.tabs("tabs");
                    for (index = 0; index < allTabs.length; index++) {
                        iframe = allTabs[index].find('iframe');
                        if (iframe.length == 0)
                            continue;
                        if ($.getUrlPath(iframe[0].src) === url)
                            return true;
                    }
                    return false;
                }
                //刷新选项卡
                function refresh() {
                    iframe[0].contentWindow.location.href = url;
                }

                //创建选项卡
                function createTab() {
                    var content = '<div class="easyui-layout" data-options="fit:true"><iframe scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe><div>';
                    tabs.tabs('add', {
                        title: title,
                        closable: closable,
                        content: content,
                        iconCls: icon,
                        selected: 0
                    });
                }

                //选中选项卡
                function selectTab() {
                    tabs.tabs('select', index);
                }
            },
            refreshTabs: function (tabsId) {
                ///	<summary>
                ///	刷新选项卡
                ///	</summary>
                ///	<param name="tabsId" type="String">
                ///	选项卡Id
                ///	</param>
                var tabs = $('#' + tabsId);
                var tab = tabs.tabs('getSelected');
                var iframe = tab.find('iframe');
                if (iframe.length == 0)
                    return;
                iframe[0].contentWindow.location.href = iframe[0].contentWindow.location.href;
            },
            //初始化编辑窗口
            initEditDialog: function (options) {
                return $.easyui.initDialogByGrid(options, $.easyui.editNotSelectedMessage);
            },
            initDialog:function (options, msg, id) {
            ///	<summary>
            ///	初始化弹出窗口
            ///	</summary>
            ///	<param name="options" type="Object">
            ///	选项
            ///	</param>
            ///	<param name="msg" type="String">
            ///	消息
            ///	</param>
            ///	<param name="id" type="String">
            ///	业务编号
            ///	</param>
                if (!id) {
                    $.easyui.message.warn(msg);
                    return false;
                }
                options.url = $.joinUrl(options.url, "id=" + id);
                return true;
            },
            initDialogByGrid:function (options, msg, gridId) {
                ///	<summary>
                ///	初始化弹出窗口-表格
                ///	</summary>
                ///	<param name="options" type="Object">
                ///	选项
                ///	</param>
                ///	<param name="msg" type="String">
                ///	消息
                ///	</param>
                ///	<param name="gridId" type="String">
                ///	表格Id
                ///	</param>
                var form = $.easyui.getQueryForm();
                gridId = gridId || form.attr("gridId") || $.easyui.gridId;
                var row = $.easyui.getGrid(gridId).datagrid('getSelected');
                return $.easyui.initDialog(options, msg, row && row.Id);
            }
        };
    })();
    //消息窗口
    $.easyui.message = (function () {
        return {
            getMessager: function () {
                return $parent.messager;
            },
            info: function (msg, title) {
                ///	<summary>
                ///	弹出信息框
                ///	</summary>
                ///	<param name="msg" type="String">
                ///	内容
                ///	</param>
                ///	<param name="title" type="String">
                ///	标题
                ///	</param>
                if (!msg)
                    return;
                $.easyui.message.getMessager().alert(title || "信息", msg, 'info');
            },
            warn: function (msg, title) {
                ///	<summary>
                ///	弹出警告框
                ///	</summary>
                ///	<param name="msg" type="String">
                ///	内容
                ///	</param>
                ///	<param name="title" type="String">
                ///	标题
                ///	</param>
                if (!msg)
                    return;
                $.easyui.message.getMessager().alert(title || "错误", msg, 'error');
            },
            confirm: function (msg, callback, title) {
                ///	<summary>
                ///	弹出确认框
                ///	</summary>
                ///	<param name="msg" type="String">
                ///	内容
                ///	</param>
                ///	<param name="callback" type="Function">
                ///	点击ok按钮后的回调函数
                ///	</param>
                ///	<param name="title" type="String">
                ///	标题
                ///	</param>
                if (!msg) {
                    callback();
                    return;
                }
                $.easyui.message.getMessager().confirm(title || "确认", msg, function (result) {
                    if (result)
                        callback();
                });
            }
        };
    })();
    //grid的列的数据格式化
    $.easyui.format = (function () {
        return {
            //格式化布尔值
            Bool: function (value) {
                if (value === true || value === 'true' || value === 1 || value === '1')
                    return "是";
                return "否";
            }
        };
    })();

    //发送请求
    $.easyui.ajax = function (url, data, callback, dataType, type, async) {
        dataType = dataType || "json";
        type = type || 'POST';
        $.ajax({
            type: type,
            url: url,
            data: data,
            dataType: dataType,
            cache: false,
            async: async,
            success: function (result) {
                if (callback)
                    callback(result);
            },
            error: function (result) {
                $.easyui.showMessage(result);
            }
        });
    }
    //显示消息
    $.easyui.showMessage = function (result) {
        if (result.Code === $.easyui.state.ok)
            $.easyui.message.info(result.Message);
        else if (result.Code === $.easyui.state.fail)
            $.easyui.message.warn(result.Message);
    };
})(jQuery);

