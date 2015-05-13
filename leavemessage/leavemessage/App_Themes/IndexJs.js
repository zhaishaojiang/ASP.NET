function show() {
    document.getElementById("unfold").style.display = "none";
    document.getElementById("fold").style.display = "block";

}
function hide() {
    document.getElementById("unfold").style.display = "block";
    document.getElementById("fold").style.display = "none";
}
function change() {
    document.getElementById('img').src =
        document.getElementById('img').src + '?' + 1;
}