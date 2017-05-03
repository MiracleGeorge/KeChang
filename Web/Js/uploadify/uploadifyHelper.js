//文件上传帮助js

$(function () {
    $("#file_upload").uploadify({
        buttonText: "选择附件",
        swf: "/Js/uploadify/uploadify.swf",
        uploader: "/Js/uploadify/FileUpload.aspx",
        formData: {
            act: "UploadFile",
            tableId: $("input[type='hidden'][id$='hf_tableId']").val(),
            tableFileId: $("input[type='hidden'][id$='hf_tableFileId']").val()
        },
        onUploadSuccess: function (file, data, response) {
            var ret = eval("(" + data + ")");
            if (ret.flag == "1") {
                var node = "<div style=\"margin-bottom: 5px;\">\
                    <a href=\"" + ret.filePath + "\" style=\"margin-right: 5px;\" target=\"_blank\">" + ret.fileName + "</a>\
                    <a href=\"javascript:;\" data-id=\"" + ret.fileId + "\" style=\"color: Red;\" onclick=\"deleteFile(this)\">删除</a>\
                </div>";
                $(".fileInfo").append(node);
            }
            else if (ret.flag == "-1") {
                top.msgbox.prompt(ret.msg, 3);
            }
            else {
                top.msgbox.prompt(ret.msg, 1);
            }
        }
    });
})

//删除文件
function deleteFile(obj) {
    top.Dialog.confirm("您确定要删除该附件吗？", function () {
        $.ajax({
            type: "POST",
            url: "/Js/uploadify/FileUpload.aspx",
            data: {
                "act": "DeleteFile",
                "fileId": $(obj).attr("data-id")
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $(obj).closest("div").remove();
                    }
                    else if (ret.flag == "-1") {
                        top.msgbox.prompt(ret.msg, 3);
                    }
                    else {
                        top.msgbox.prompt(ret.msg, 1);
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！", 1);
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！", 1);
            }
        });
    })
}