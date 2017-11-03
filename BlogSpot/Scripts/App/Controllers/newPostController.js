define(['angular', 'jquery', 'tinymce'], function (angular, jq, tinymce) {
    angular.module("blogApp").register.controller("newPostController", function ($scope, $http) {
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

        $scope.tags = [];

        $scope.addNewTag = function (tagName) {
            if (tagName) {
                Tag = {
                    Id: 0,
                    Name: tagName
                };

                if (indexOfProp($scope.tags, 'Name', tagName) === -1)
                    $scope.tags.push(Tag);

                $scope.tagName = null;
            }
        };

        $scope.removeTag = function (index) {
            $scope.tags.splice(index, 1);
        };

        function indexOfProp(array, prop, value) {
            for (var i = 0; i < array.length; i += 1) {
                if (array[i][prop] === value) {
                    return i;
                }
            }
            return -1;
        }
    
        $scope.post = function() {
            var content = tinymce.activeEditor.getContent();
            var data = {
                Id: 0,
                Tiltle: "",
                ShortDescription: "",
                Description: content,
                Meta: "",
                Slug: "",
                Published: true,
                PostedOnDay: "",
                PostedOnMonth: "",
                PostedOnYear: "",
                PostedOnTime: "",
                DateTime: null,
                Category: null,
                Tags: []
            };

            $http.post("http://localhost:9992/api/test/add", data, null);
        };
    });
});