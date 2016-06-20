$(document).ready(function () {

    $('[id*=txtPlainText]').keydown(function () {

        if ($('[id*=txtPlainText]').val() == '') {
            $('[id*=txtResult]').val('');
        }

    });

});
