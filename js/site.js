// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var audio1 = document.getElementById("hoverAudio1");
var audio2 = document.getElementById("hoverAudio2");
var audio3 = document.getElementById("hoverAudio3");

function playAudio1() {
    audio1.play();
}

function pauseAudio1() {
    audio1.pause();
    audio1.currentTime = 0;
}

function playAudio2() {
    audio2.play();
}

function pauseAudio2() {
    audio2.pause();
    audio2.currentTime = 0;
}

function playAudio3() {
    audio3.play();
}

function pauseAudio3() {
    audio3.pause();
    audio3.currentTime = 0;
}

var video1 = document.getElementById("hoverVideo1");
var hoverTimer;

function playVideo1() {
    hoverTimer = setTimeout(function () {
        video1.style.opacity = '1';
        video1.style.display = 'block'; // Show the video
        video1.play();
        video1.currentTime = 7.01;
    }, 1000); // 1000 milliseconds = 2 seconds
}

function pauseVideo1() {
    clearTimeout(hoverTimer); // Clear the hover timer
    video1.pause();
    video1.currentTime = 7.01;
    video1.style.display = 'none'; // Hide the video
    video1.style.opacity = '0';
}

