document.getElementById('org-finder-form').addEventListener('submit', (e) => {
    e.preventDefault();
    
    const name = document.getElementById('name').value;
    const course = document.getElementById('course').value;
    const interest = document.getElementById('interest').value;
    const passion = document.getElementById('passion').value;

    if (!interest || !passion) {
        alert('Please select both interest and passion.');
        return;
    }

    alert(`Hi ${name}, based on your interest in ${interest} and passion for ${passion}, we will find organizations for you!`);
});
