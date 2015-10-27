//判断是否包含
String.prototype.contains = function (value) {
    if (!value)
        return false;
    return this.toLowerCase().indexOf(value.toLowerCase()) != -1;
}
//判断起始匹配
String.prototype.startsWith = function (value) {
    if (!value)
        return false;
    return new RegExp("^" + value.toLowerCase()).test(this.toLowerCase());
}
//判断结束匹配
String.prototype.endsWith = function (value) {
    if (!value)
        return false;
    return new RegExp(value.toLowerCase() + "$").test(this.toLowerCase());
}
//从起始位置开始截断
String.prototype.trimStart = function (value) {
    value = ("(" + value + ")");
    return this.replace(new RegExp("^" + value + "*", "g"), "");
};
//格式化日期
Date.prototype.format = function (formatString) {
    ///	<summary>
    ///	格式化日期
    ///	</summary>
    ///	<param name="formatString" type="String">
    ///	格式化字符串，可选值：
    /// (1) y : 年
    /// (2) M : 月
    /// (3) d : 日 
    /// (4) H : 时 
    /// (5) m : 分
    /// (6) s : 秒
    /// (7) S : 毫秒
    ///	</param>
    ///	<returns type="String" />
    var options = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "H+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "S": this.getMilliseconds()
    };
    if (/(y+)/.test(formatString))
        formatString = formatString.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var option in options)
        if (new RegExp("(" + option + ")").test(formatString)) {
            var value = options[option];
            formatString = formatString.replace(RegExp.$1, (RegExp.$1.length == 1) ? (value) : (("00" + value).substr(("" + value).length)));
        }
    return formatString;
}
//数组是否包含指定元素
Array.prototype.contains = function (item) {
    return $.inArray(item, this) != -1;
}
//移除数组指定元素
Array.prototype.remove = function (item) {
    var index = $.inArray(item, this);
    if (index == -1)
        return;
    this.splice(index, 1);
}