var Collection = Collection || {};

$.extend(true, Collection, {
    Common: {
        OpenModal: function (title, body, size, onclose, onconfirm) {
            $.ajax({
                type: 'GET',
                url: Collection.Common.UrlHelper('Common', 'OpenModal'),
                cache: false,
                data: { title: title, body: body, size: size, onclose: onclose, onconfirm: onconfirm },
                success: function (data) {
                    $('#modal-container').html(data);
                    $('#collectionModal').modal('show');
                }
            });
        },

        CloseModal: function () {
            $('#modal-container').html('');
            $('.modal-backdrop').remove();
        },

        UrlHelper: function (controller, action) {
            return controller + '/' + action;      
        }

    }
});