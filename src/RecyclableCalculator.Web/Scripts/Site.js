const weightInputEl = document.getElementById('RecyclableItemAddRequest_Weight');
const typeSelectEl = document.getElementById('RecyclableTypeId');
const computedRateEl = document.getElementById('RecyclableItemAddRequest_ComputedRate');
const weightInputValidationEl = document.getElementById('weight-validation');
const saveButtonEl = document.querySelector('[type="submit"]');
const resetButtonEl = document.querySelector('[type="reset"]');

$(function () {    
    weightInputEl.addEventListener('input', () => computeRate());
    typeSelectEl.addEventListener('change', () => computeRate());
    resetButtonEl.addEventListener('click', () => resetSaveButton());
})

function computeRate() {
    const weight = weightInputEl.value;
    const selectedType = typeSelectEl.options[typeSelectEl.selectedIndex];

    const selectedTypeRate = selectedType.dataset.rate;
    const selectedTypeMinKg = selectedType.dataset.minkg;
    const selectedTypeMaxKg = selectedType.dataset.maxkg;

    computedRateEl.value = (selectedTypeRate * weight).toFixed(2);

    if (computedRateEl.value < selectedTypeMinKg || computedRateEl.value > selectedTypeMaxKg) {
        weightInputValidationEl.textContent = `Weight must be between ${selectedTypeMinKg} and ${selectedTypeMaxKg} kg.`;
        saveButtonEl.disabled = true;
    } else {
        resetSaveButton();
    }
}

function resetSaveButton() {
    weightInputValidationEl.textContent = '';
    saveButtonEl.disabled = false;
}