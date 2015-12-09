$(function () {
    $('#cloud').jQlouds();
    var $userName = $("#txtUserName");
    var $password = $("#txtPasword");
    var $validateCode = $("#txtValidateCode");
    var $rememberMe = $("#chkRememberMe");
    //清空验证码
    function clearValidateCode() {
        refreshValidateCode();
        $validateCode.val("");
    }
    //用户名回车
    $userName.keydown(function (event) {
        if (event.which == 13)
            $password.focus();
    });
    //密码回车
    $password.keydown(function (event) {
        if (event.which == 13)
            $validateCode.focus();
    });
    //验证码回车
    $validateCode.keydown(function (event) {
        if (event.which == 13)
            $("#btnLogin").click();
    });
    //重置
    $("#btnReset").click(function () {
        $userName.val("");
        $password.val("");
        clearValidateCode();
        $userName.focus();
    });
    //登录
    $("#btnLogin").click(function () {
        $.ajax({
            dataType: "json",
            type: "POST",
            url: "/Security/LogIn",
            data: "UserNameOrEmail=" + $userName.val() + "&password=" + $password.val() + "&validateCode=" + $validateCode.val() + "&rememberMe=" + $rememberMe.is(':checked'),
            beforeSend: function () {
                if ($.trim($userName.val()) === "") {
                    alert("用户名或邮箱不能为空");
                    $userName.focus();
                    $userName.val("");
                    return false;
                }
                if ($.trim($password.val()) === "") {
                    alert("密码不能为空");
                    $password.focus();
                    $password.val("");
                    return false;
                }
                if ($.trim($validateCode.val()) === "") {
                    alert("验证码不能为空");
                    clearValidateCode();
                    $validateCode.focus();
                    return false;
                }
                $("#loading").show();
                return true;
            },
            success: function (data) {
                if (data.Code === 1) {
                    location.href = "/Home/Index";
                    return;
                }
                //clearValidateCode();
                //if (data === "ValidateCodeError") {
                //    $validateCode.focus();
                //    alert("验证码错误");
                //    return;
                //}
                if (data.code === "S3002") {
                    $userName.val("");
                    $userName.focus();
                }
                if (data.code === "S3004") {
                    $password.val("");
                    $password.focus();
                }
                alert(data.Message);
            },
            complete: function () {
                $("#loading").hide();
            }
        });
    });
});