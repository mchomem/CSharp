$(document).ready(function() {

    $('#btnPesquisarJSON').click(function () {        

        var parans = '{ sexo: ' + '\'' + $('[id*=ddlSexo]').val() + '\' }';
        getData('http://localhost:81/Funcionarios/Funcionarios.asmx/ObterFuncionariosPorSexoJSON', parans);

    });

});


function getData(pUrl, parans) {

    $.ajax({
        type:          'POST'
        , url:         pUrl
        , contentType: 'application/json; charset=utf-8'
        , dataType:    'json'
        , data:        parans
        , success:     function (data, status) {
            
            var info = $.parseJSON(data.d);

            setDataGrid(info);

        }
        , error:       function (xmlHttpRequest, status, error) {
            alert('Falha: ' + error);
        }
    });

}

function setDataGrid(infoJSON) {

    // Remove a gridJSON.
    if ($('#gridJSON').length > 0) {
        $('#gridJSON').remove();
    }

    // Remove a GridView .NET
    if ($('[id*=gvwFuncionarios]').length > 0) {
        $('[id*=gvwFuncionarios]').remove();
    }

    var grid = '';
    var data = '';

    for (var i = 0; i < infoJSON.length; i++) {

        data += '<tr>';
        data +=     '<td>' + infoJSON[i].idt_func      + '</td>'
        data +=     '<td>' + infoJSON[i].cpf_func      + '</td>'
        data +=     '<td>' + infoJSON[i].nom_func      + '</td>'
        data +=     '<td>' + infoJSON[i].ci_func       + '</td>'
        data +=     '<td>' + infoJSON[i].email_func    + '</td>'
        data +=     '<td>' + infoJSON[i].tel_res_func  + '</td>'
        data +=     '<td>' + infoJSON[i].tel_cel_func  + '</td>'
        data +=     '<td>' + infoJSON[i].dat_nasc_func + '</td>'
        data +=     '<td>' + infoJSON[i].sexo_func     + '</td>'
        data += '</tr>';

    }

    grid += '<table id="gridJSON" style="font-size: 14px; border-collapse: collapse; border: 1px solid black; width: 100%;">';
    grid +=     '<thead style="border-bottom: 1px solid black;">';
    grid +=         '<tr>';
    grid +=             '<th>ID</th>'
    grid +=             '<th>CPF</th>'
    grid +=             '<th>Nome</th>'
    grid +=             '<th>RG</th>'
    grid +=             '<th>Email</th>'
    grid +=             '<th>Tel. Residencial</th>'
    grid +=             '<th>Tel. Celular</th>'
    grid +=             '<th>Data Nasc.</th>'
    grid +=             '<th>Sexo</th>'
    grid +=         '</tr>';
    grid +=     '</thead>';
    grid +=     '<tbody>';
    grid +=         data;
    grid +=     '</tbody>';
    grid +=     '<tfoot>';
    grid +=     '</tfoot>';
    grid += '</table>';

    $('#divJSON').append(grid);

}