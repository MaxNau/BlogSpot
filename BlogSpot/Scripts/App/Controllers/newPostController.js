define(['angular', 'jquery', 'tinymce'], function (angular, jq, tinymce) {
    angular.module("blogApp").register.controller("newPostController", function ($scope) {
        if (tinymce.activeEditor != null) {
            tinymce.EditorManager.execCommand('mceRemoveEditor', true, 'texteditor');
        }

        tinymce.init({
            selector: '#texteditor',
            plugins: 'advlist autolink link image lists charmap print preview',
            paste_data_images: true,
            content_css: "content/tinymceExtended.css",
            file_picker_callback: function (callback, value, meta) {
                if (meta.filetype == 'image') {
                    $('#upload').trigger('click');
                    $('#upload').on('change', function () {
                        var file = this.files[0];
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            callback(e.target.result, {
                                alt: ''
                            });
                        };
                        reader.readAsDataURL(file);
                    });
                }
            }
        });

        $scope.resizePostTitleHeight = function ($event) {
            $event.target.style.height = "5px";
            $event.target.style.height = ($event.target.scrollHeight) + "px";
        }
    });
});