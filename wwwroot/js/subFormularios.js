function VerDivRoles() {
    var d = document.getElementById("visualizarRoles");
    if (d.style.display == "block") {
        d.style.display = "none";
        document.getElementById("visualizarMenu").style.display = "none";
    } else {
        d.style.display = "block";
        document.getElementById("visualizarMenu").style.display = "none";
    }
}

function VerDivMenu() {
    var d = document.getElementById("visualizarMenu");
    if (d.style.display == "none") {
        d.style.display = "block";
        document.getElementById("visualizarRoles").style.display = "none";
    } else {
        d.style.display = "none";
        document.getElementById("visualizarRoles").style.display = "none";
    }
}