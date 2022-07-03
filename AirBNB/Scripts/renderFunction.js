﻿function renderDescription(des, size) {
    let words = des.split(' ');
    if (size > words.length)
        size = words.length;
    let str = "";
    for (var i = 0; i < size; i++)
        str += words[i] + " ";
    str += "...";
    return str;
}


function renderPersons(num) { 
    let str = "";
    for (var i = num; i >= 1; i--)
        str += '<span class="mdi mdi-odnoklassniki"></span>';
    return str;
}

function renderStars(score, reviews) { 
    if (reviews > 0)
        str = "<p style='text-align:center'>" + score.toFixed(1) + ' (' + reviews + ')</p>';
    else str = "<p>" + score.toFixed(1) + '</p>';
    for (var i = score; i >= 1; i--) {
        str += '<span class="fa-star"></span>';
    }
    if (i > 0.5)
        str += '<span class="fa-star-half"></span>';
    return str;
}
