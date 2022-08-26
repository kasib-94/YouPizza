function myFunction() {
    if ($("#myCheck").is(':checked')) {
        $("#dateBlock").show()
    } else {
        $("#dateBlock").hide()
    }
}


function loadTable(filter) {


    if ($("#myCheck").is(':checked') == false) {

        if ($.fn.DataTable.isDataTable("#table_id")) {
            $('#table_id').DataTable().clear().destroy();
        }

        console.log("unchecked")
        console.log(filter)
        const jsonInput = {
            filter,
            Min: null,
            Max: null
        };
        $('#table_id').DataTable({
            ajax: {
                url: `/Admin/Order/GetData/`,
                data: {jsonInput: JSON.stringify(jsonInput)},
                type: 'POST',
                dataType: `JSON`,
            },
            type: 'POST',
            "columns": [
                {"data": "name", "width": "15%"},
                {"data": "streetAdress", "width": "15%"},
                {"data": "totalPrice", "width": "15%"},
                {"data": "timeCreated", "width": "15%"},
                {"data": "phoneNumber", "width": "15%"},
            ]

        })
    }
    if ($("#myCheck").is(':checked') == true) {
        if ($.fn.DataTable.isDataTable("#table_id")) {
            $('#table_id').DataTable().clear().destroy();
        }

        const dateMin = $("#dateMin").val()
        console.log(dateMin)
        const dateMax = $("#dateMax").val()
        console.log(dateMax)
        const jsonInput = {
            filter: filter,
            Min: dateMin,
            Max: dateMax,
        }

        console.log("checked")
        console.log(jsonInput)
        $('#table_id').DataTable({
            ajax: {
                url: `/Admin/Order/GetData/`,
                data: {jsonInput: JSON.stringify(jsonInput)},
                type: 'POST',
                dataType: `json`,

            },

            "columns": [
                {"data": "name", "width": "15%"},
                {"data": "streetAdress", "width": "15%"},
                {"data": "totalPrice", "width": "15%"},
                {"data": "timeCreated", "width": "15%"},
                {"data": "phoneNumber", "width": "15%"},
            ]

        })
    }

}