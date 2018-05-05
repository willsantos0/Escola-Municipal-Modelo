var Util = {

    ValidateCPF: function(c) {
        if ((c = c.replace(/[^\d]/g, "")).length != 11)
            return null;


        // Validação mais precisa. (No momento não é necessária)
        //var r;
        //var s = 0;

        //for (i = 1; i <= 9; i++)
        //    s = s + parseInt(c[i - 1]) * (11 - i);

        //r = (s * 10) % 11;

        //if ((r == 10) || (r == 11))
        //    r = 0;

        //if (r != parseInt(c[9]))
        //    return null;

        //s = 0;

        //for (i = 1; i <= 10; i++)
        //    s = s + parseInt(c[i - 1]) * (12 - i);

        //r = (s * 10) % 11;

        //if ((r == 10) || (r == 11))
        //    r = 0;

        //if (r != parseInt(c[10]))
        //    return null;

        return c;
        
    },


    isDate: function(txtDate)
    {
        var currVal = txtDate;

        if (currVal == '')
            return false;

        var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var dtArray = currVal.match(rxDatePattern);

        if (dtArray == null)
            return false;

        dtDay = dtArray[1];
        dtMonth = dtArray[3];
        dtYear = dtArray[5];

        if (dtMonth < 1 || dtMonth > 12)
            return false;
        else if (dtDay < 1 || dtDay > 31)
            return false;
        else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
            return false;
        else if (dtMonth == 2) {
            var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));

            if (dtDay > 29 || (dtDay == 29 && !isleap))
                return false;
        }
        return true;
    },

      
    loadDatatableAlunos: function() {
   
        $('#listTableAlunos').DataTable({
            responsive: true,
            destroy: true,
            "language": {
                "sSearchPlaceholder": "Digite aqui...",
                "sEmptyTable": "Nenhum aluno encontrado",
                "sInfo": "_START_ a _END_ de _TOTAL_ alunos",
                "sInfoEmpty": "0 a 0 de 0 alunos",
                "sInfoFiltered": "(Filtrados de _MAX_ alunos)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "_MENU_ alunos",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Carregando...",
                "sZeroRecords": "Nenhum aluno encontrado",
                "sSearch": "Pesquisar: ",
                "oPaginate": {
                    "sNext": "Proximo",
                    "sPrevious": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Ultimo"
                },

            },


        });

    },

    validateForm: function (id) {

        var submit = $('#submit');

        var valid = $(id).validate().checkForm();
        if (valid) {
            submit.prop('disabled', false);
            submit.removeClass('isDisabled');
            return true;
        } else {
            submit.prop('disabled', 'disabled');
            submit.addClass('isDisabled');
            return false;
        }
    },

    formatarData: function (d) {
        var date = new Date(d);
        var year = date.getFullYear();

        var month = (1 + date.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;

        var day = date.getDate().toString();
        day = day.length > 1 ? day : '0' + day;

        return day + '/' + month + '/' + year;
    }

}