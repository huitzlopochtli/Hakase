// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#customerTable').DataTable({
        "language": {
            "sEmptyTable": "テーブルにデータがありません",
            "sInfo": " _TOTAL_ 件中 _START_ から _END_ まで表示",
            "sInfoEmpty": " 0 件中 0 から 0 まで表示",
            "sInfoFiltered": "（全 _MAX_ 件より抽出）",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "_MENU_ 件表示",
            "sLoadingRecords": "読み込み中...",
            "sProcessing": "処理中...",
            "sSearch": "検索:",
            "sZeroRecords": "一致するレコードがありません",
            "oPaginate": {
                "sFirst": "先頭",
                "sLast": "最終",
                "sNext": "次",
                "sPrevious": "前"
            },
            "oAria": {
                "sSortAscending": ": 列を昇順に並べ替えるにはアクティブにする",
                "sSortDescending": ": 列を降順に並べ替えるにはアクティブにする"
            }
        }
    });
});

$(document).ready(function () {
    $('#customerTable2').DataTable({
        "language": {
            "sEmptyTable": "テーブルにデータがありません",
            "sInfo": " _TOTAL_ 件中 _START_ から _END_ まで表示",
            "sInfoEmpty": " 0 件中 0 から 0 まで表示",
            "sInfoFiltered": "（全 _MAX_ 件より抽出）",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "_MENU_ 件表示",
            "sLoadingRecords": "読み込み中...",
            "sProcessing": "処理中...",
            "sSearch": "検索:",
            "sZeroRecords": "一致するレコードがありません",
            "oPaginate": {
                "sFirst": "先頭",
                "sLast": "最終",
                "sNext": "次",
                "sPrevious": "前"
            },
            "oAria": {
                "sSortAscending": ": 列を昇順に並べ替えるにはアクティブにする",
                "sSortDescending": ": 列を降順に並べ替えるにはアクティブにする"
            }
        }
    });
});