$(document).ready(function () {
   
    GetAllAlunos();
   
    $("#formulario").validate();
    $('#inputXML').rules('add', {
        required: true,
        accept: "text/xml",
        messages: {
            required: "O arquivo é obrigatório",
            accept: "Insira o arquivo com o formato xml"
        }
    });

    $('#formulario').on('blur keyup change', '#inputXML', function (event) {       
        Util.validateForm('#formulario');       
    });
    

    $("#listTableAlunos").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm({
            title: "Excluir Aluno?",
            message: 'Deseja remover o aluno "' + button.attr('data-aluno-nome') + '"?',
            className: 'bb-error-token-modal',
            buttons: {
                confirm: {
                    label: '<i class="fa fa-check"></i> Sim',
                    className: 'bb-btn btn-success'
                },
                cancel: {
                    label: '<i class="fa fa-times"></i> Não',
                    className: 'bb-btn btn-danger'
                }
            },
            callback: function (result) {
                       
                if (result) {
                    DeleteAluno(button);
                }

            }

        });
    });

});

// Busca todos os Alunos
function GetAllAlunos() {

    var baseURL = 'http://localhost:6684/';

    $.ajax({
        type: 'GET',
        url: baseURL + 'api/alunos',
        contentType: "json",
        dataType: "json",
        success: function (data) {

            $.each(data, function (key, value) {
                
                var jsonData = JSON.stringify(value);
                
                var alunoEntity = $.parseJSON(jsonData);

                var id = alunoEntity.Id;
                var cpf = alunoEntity.CPF;
                var nomeAluno = alunoEntity.NomeAluno;
                var dataNascimento = alunoEntity.DataNascimento;
                var nomeMae = alunoEntity.NomeMae;
                var endereco = alunoEntity.Endereco;

                $('<tr class="js-delete" data-aluno-id =' + id + ' data-aluno-nome = "' + nomeAluno + '">' + 
                    '<td>' + cpf + '</td>' +
                    '<td>' + nomeAluno + '</td>' +
                    '<td>' + Util.formatarData(dataNascimento) + '</td>' +
                    '<td>' + nomeMae + '</td>' +
                    '<td>' + endereco + '</td>' +
                    '</tr>').appendTo('#listTableAlunos tbody');

            });

            Util.loadDatatableAlunos();
        },
        error: function (xhr) {
            bootbox.alert({
                message: xhr.responseText,
                callback: function () {
                    console.log(xhr.responseText);
                }
            });
        }
    });
}

// Exclui um aluno
function DeleteAluno(button) {

    var baseURL = 'http://localhost:6684/';
    
    $.ajax({
        url: baseURL + "/api/alunos/" + button.attr("data-aluno-id"),
        method: "DELETE",
        success: function () {
            bootbox.alert({
                message: 'O aluno "' + button.attr('data-aluno-nome') + '" foi excluído com sucesso!',
                callback: function () {
                    console.log('Aluno excluído com sucesso!');
                }
            });

            //$('#listTableAlunos').dataTable().fnDestroy();
            //$('#listTableAlunos tbody').html('');
            $(button).closest('tr').remove();
        },
        error: function (xhr) {
            bootbox.alert({
                message: xhr.responseText,
                callback: function () {
                    console.log(xhr.responseText);
                }
            });
        }
    });
}

//Inserir estudantes através de um arquivo XML
function InsertAlunos(alunos) {

    var baseURL = 'http://localhost:6684/';

    $.ajax({
        type: "POST",
        url: baseURL + "api/alunos/InsertList",
        data: JSON.stringify(alunos),
        contentType: "application/json; charset=utf-8",
        success: function (data, status, jqXHR) {
            bootbox.alert("Alunos inseridos com sucesso.");

            $('#listTableAlunos').dataTable().fnDestroy();
            $('#listTableAlunos tbody').html('');
            GetAllAlunos();
        },
        error: function (xhr) {
            bootbox.alert(xhr.responseText);
        }
    });
}     
                                                          
function ReadXML() {
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.xml)$/;

    var save = false;
   
    if (typeof (FileReader) != "undefined") {
        var reader = new FileReader();
        reader.onload = function (e) {
            var xml = $.parseXML(e.target.result);

            var listAlunos = [];

            $(xml).find('Aluno').each(function (index, value) {
                var cpf = $(this).find('CPF').text();
                var nomeAluno = $(this).find('NomeAluno').text();
                var dataNascimento = $(this).find('DataNascimento').text();
                var nomeMae = $(this).find('NomeMae').text();
                var endereco = $(this).find('Endereco').text();
                                          
                if (cpf.trim() == '' || cpf == null) {
                    bootbox.alert('Erro no registro: ' + (index + 1) + '. CPF é obrigatório!');
                    return;
                }

                var cpfValid = Util.ValidateCPF(cpf);

                if (cpfValid == null) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. CPF deve estar no formato 00000000000!');
                    save = false;
                    return;
                } else {
                    cpf = cpfValid;
                }

                   
                if (nomeAluno.trim() == '' || nomeAluno == null) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. Nome do aluno é obrigatório!');
                    save = false;
                    return;
                }

                if (!Util.isDate(dataNascimento.trim())) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. Data de nascimento está com o formato inválido! Deverá estar com o formato: dd/MM/yyyy');
                    save = false;
                    return;
                }


                if (dataNascimento.trim() == '' || dataNascimento == null) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. Data de nascimento é obrigatório!');
                    save = false;
                    return;
                }

                if (nomeMae.trim() == '' || nomeMae == null) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. Nome da mãe é obrigatório!');
                    save = false;
                    return;
                }

                if (endereco.trim() == '' || endereco == null) {
                    bootbox.alert('Erro na linha: ' + (index + 1) + '. Endereço é obrigatório!');
                    save = false;
                    return;
                }

                // Conversão para salvar na API
                var novaDataNascimento = dataNascimento.trim().split("/").reverse().join("-");

                var alunoEntity = {
                    CPF: cpf.trim(),
                    NomeAluno: nomeAluno.trim(),
                    DataNascimento: novaDataNascimento.trim(),
                    NomeMae: nomeMae.trim(),
                    Endereco: endereco.trim()
                };

                listAlunos.push(alunoEntity);
                save = true;
            });

            if (save && listAlunos.length > 0)
                InsertAlunos(listAlunos);
        }
        reader.readAsText($("#inputXML")[0].files[0], "ISO-8859-1");
    }
    else {
        alert("Desculpe! Seu navegador não suporta a inclusão deste arquivo! Por favor, troque de navegador!");
    }
}
  