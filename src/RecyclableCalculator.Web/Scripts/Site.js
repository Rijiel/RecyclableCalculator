const weightInputEl = document.querySelector('.weight-input');
const typeSelectEl = document.getElementById('RecyclableTypeId');
const computedRateEl = document.querySelector('.computed-rate');
const computedRateValidationEl = document.querySelector('.computed-rate-val');
const saveButtonEl = document.querySelector('[type="submit"]');
const resetButtonEl = document.querySelector('[type="reset"]');

// Default values for reset
const defaultRateValue = computedRateEl.value;
const defaultSelectedTypeMinKg = typeSelectEl.options[typeSelectEl.selectedIndex].dataset.minkg;
const defaultSelectedTypeMaxKg = typeSelectEl.options[typeSelectEl.selectedIndex].dataset.maxkg;

$(function () {    
    computeRate();

    weightInputEl.addEventListener('input', () => computeRate());
    typeSelectEl.addEventListener('change', () => computeRate());
    resetButtonEl.addEventListener('click', () => onClickReset());
})

function computeRate() {
    const weight = weightInputEl.value;
    const selectedType = typeSelectEl.options[typeSelectEl.selectedIndex];

    const selectedTypeRate = selectedType.dataset.rate;
    const selectedTypeMinKg = selectedType.dataset.minkg;
    const selectedTypeMaxKg = selectedType.dataset.maxkg;

    // Computed rate = rate * weight, rounded to 2 decimal places
    const computedRate = selectedTypeRate * weight;
    computedRateEl.value = (computedRate).toFixed(2);

    // Check if computed rate is between min and max, prevent submission if not
    if (computedRate < selectedTypeMinKg || computedRate > selectedTypeMaxKg) {
        computedRateValidationEl.textContent = `Computed rate must be between ${selectedTypeMinKg} and ${selectedTypeMaxKg} kg.`;
        saveButtonEl.disabled = true;
    } else {
        resetSaveButton();
    }
}

function onClickReset() {
    // Compute default rate
    if (defaultRateValue < defaultSelectedTypeMinKg || defaultRateValue > defaultSelectedTypeMaxKg) {
        computedRateValidationEl.textContent = `Computed rate must be between ${defaultSelectedTypeMinKg} and ${defaultSelectedTypeMaxKg} kg.`;
        saveButtonEl.disabled = true;
    } else {
        resetSaveButton();
    }
}

function resetSaveButton() {
    computedRateValidationEl.textContent = '';
    saveButtonEl.disabled = false;
}