var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#DT_load').DataTable(
        {
            "ajax": {
                "url": "/api/book",
                "type": "GET",
                "datatype": "json"
            },
            "column": [
                {
                    "data": "name", 
                    "width": "30%"
                },
                {
                    "data": "author",
                    "width": "30%"
                },
                {
                    "data": "isbn",
                    "width": "30%"
                },
                {
                    "data": "id",
                    "width": "30%",
                    "render": function (data) {
                        return `<div class="text-center"
                                <a href="/BookList/Edit?id=${data}" class = 'btn btn-success text-white' style='cursor:pointer; width:100px'>
                                   Edit</a>
                                &ndsp;    
                                <a class = 'btn btn-danger text-white' style='cursor:pointer; width:100px'>
                                   Delete</a></div>`;
                    }
                },
            ],
            "language": {
                "emptyTable": "no data found"
            },
            "width": "100%"
        })
}

