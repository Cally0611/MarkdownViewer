// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Event listener used to update the preview when the "markdown-content" textarea changes.
document.getElementById('ConvertMD').addEventListener('click', function () {

    // Get references to the elements.
    const markdownContent = document.getElementById('markdown-content');
    const htmlPreview = document.getElementById('html-preview');

    // Convert Markdown to HTML.
    const htmlContent = marked.parse(markdownContent.value);

    // Sanitize the generated HTML and display it.
    htmlPreview.innerHTML = DOMPurify.sanitize(htmlContent,
        { USE_PROFILES: { html: true } });

});

document.getElementById('editor-mode').addEventListener('click', function () {

    // Toggle the presence of the class "distraction-free" on the element with the id "editor".
    document.getElementById('editor').classList.toggle('distraction-free');

});
