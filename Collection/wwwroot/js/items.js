$(document).ready(function () {
    var imageContainer = $('#item-gallery');

    $("#Images").on('change', function (e) {
        $.each(e.target.files, function (index, file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                imageContainer.append(image_template(e.target.result));
            }
            reader.readAsDataURL(file);
        });

        $('.thumb').remove();
        fill_gallery();
    });

    function image_template(image) {
        return '<div class="col-md-3 thumb">' +
                    '<div class="thumbnail">' +
                        '<div class="img-box">' +
                            '<img src="' + image + '" class="img-responsive" />' +
                        '</div>' +
                    '</div>' +
                '</div>';
    };
});