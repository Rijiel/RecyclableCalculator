const weightInputEl = document.querySelector('.weight-input');
const typeSelectEl = document.getElementById('RecyclableTypeId');
const computedRateEl = document.querySelector('.computed-rate');
const computedRateValidationEl = document.querySelector('.computed-rate-val');
const saveButtonEl = document.querySelector('[type="submit"]');
const resetButtonEl = document.querySelector('[type="reset"]');

$(function () {    
    computeRate();

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

    const computedRate = selectedTypeRate * weight;
    computedRateEl.value = (computedRate).toFixed(2);

    if (computedRate < selectedTypeMinKg || computedRate > selectedTypeMaxKg) {
        computedRateValidationEl.textContent = `Computed rate must be between ${selectedTypeMinKg} and ${selectedTypeMaxKg} kg.`;
        saveButtonEl.disabled = true;
    } else {
        resetSaveButton();
    }
}

function resetSaveButton() {
    computedRateValidationEl.textContent = '';
    saveButtonEl.disabled = false;
}