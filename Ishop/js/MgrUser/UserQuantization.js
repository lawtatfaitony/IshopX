function LoadQuantList(ID, ParentsID) {
    var url_QuantFactorNode = "/Mgr/User/GetNodeOfQuantFactor?ParentsID=" + ParentsID;
     
    $.ajax({
        url: url_QuantFactorNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 7,
                showTags: true,
                data: $.parseJSON(data),
                onNodeSelected: function (event, node) {

                    window.location = "QuantFactor?QuantFactorID=" + node.nodeid + "&Score=" + node.Score;
                }
            });
        }
    });//end ajax get json data
}

function LoadQuantFactorData(ID, ParentsID_Value, ParentsID, txtFactorNameID) {
    var url_QuantFactorNode = "/Mgr/User/GetNodeOfQuantFactor?ParentsID=" + ParentsID_Value;
   
    $.ajax({
        url: url_QuantFactorNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus",
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 3,
                showTags: true,
                data: $.parseJSON(data),
                onNodeCollapsed: function (event, node) {
                    $(ID).dropdown('toggle');
                },
                onNodeExpanded: function (event, node) {
                  
                    $(ID).dropdown('toggle');

                },
                onNodeSelected: function (event, node) {

                    $(ID).dropdown('toggle');
                    $(ParentsID).val(node.nodeid);
                    $(txtFactorNameID).val(node.text);
                }
            });
        }
    });//end ajax get json data
}