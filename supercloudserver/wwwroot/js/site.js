// SuperCloudServer Interactive Website Logic
// Powered by Celexsa Technologies

document.addEventListener('DOMContentLoaded', () => {
    // Current state
    let currentCurrency = 'INR'; // 'INR' or 'USD'
    let currentCycle = 'monthly'; // 'monthly' or 'annual'
    const usdRate = 0.012; // approx ₹83 = $1 USD

    // Navbar scroll effect
    const navbar = document.querySelector('.scs-navbar');
    window.addEventListener('scroll', () => {
        if (window.scrollY > 40) {
            navbar?.classList.add('scrolled');
        } else {
            navbar?.classList.remove('scrolled');
        }
    });

    // Platform switcher (Linux / Windows)
    const platformBtns = document.querySelectorAll('.platform-btn');
    const linuxPlanView = document.getElementById('linux-plans-view');
    const windowsPlanView = document.getElementById('windows-plans-view');
    const platformInput = document.getElementById('FormModel_Platform');

    platformBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const platform = btn.getAttribute('data-platform');
            
            platformBtns.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');

            if (platform === 'Linux') {
                linuxPlanView?.classList.remove('d-none');
                windowsPlanView?.classList.add('d-none');
                if (platformInput) platformInput.value = 'Linux';
            } else {
                linuxPlanView?.classList.add('d-none');
                windowsPlanView?.classList.remove('d-none');
                if (platformInput) platformInput.value = 'Windows';
            }
            updatePlanDropdown(platform);
        });
    });

    // Currency Switcher
    const currencyBtns = document.querySelectorAll('.currency-toggle-btn');
    currencyBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            currentCurrency = btn.getAttribute('data-currency');
            currencyBtns.forEach(b => b.classList.remove('active', 'btn-primary', 'btn-outline-primary'));
            btn.classList.add('active', 'btn-primary');
            currencyBtns.forEach(b => {
                if (b !== btn) b.classList.add('btn-outline-primary');
            });
            updatePricingDisplay();
        });
    });

    // Billing Cycle Switcher (Monthly / Annual)
    const cycleRadios = document.querySelectorAll('input[name="billingCycle"]');
    cycleRadios.forEach(radio => {
        radio.addEventListener('change', () => {
            currentCycle = radio.value;
            updatePricingDisplay();
        });
    });

    function updatePricingDisplay() {
        const priceBoxes = document.querySelectorAll('.plan-price-box');
        priceBoxes.forEach(box => {
            const monthlyInr = parseFloat(box.getAttribute('data-inr-monthly') || '0');
            const annualInr = parseFloat(box.getAttribute('data-inr-annual') || (monthlyInr * 12 * 0.85).toString());
            const monthlyUsd = parseFloat(box.getAttribute('data-usd-monthly') || (monthlyInr * usdRate).toString());
            const annualUsd = parseFloat(box.getAttribute('data-usd-annual') || (monthlyUsd * 12 * 0.85).toString());

            const symbolEl = box.querySelector('.plan-currency');
            const amountEl = box.querySelector('.plan-amount');
            const periodEl = box.querySelector('.plan-period');

            if (!symbolEl || !amountEl || !periodEl) return;

            if (currentCurrency === 'INR') {
                symbolEl.textContent = '₹';
                if (currentCycle === 'monthly') {
                    amountEl.textContent = monthlyInr.toLocaleString('en-IN');
                    periodEl.textContent = '/ month';
                } else {
                    const monthlyEquiv = Math.round(annualInr / 12);
                    amountEl.textContent = monthlyEquiv.toLocaleString('en-IN');
                    periodEl.innerHTML = '/ month <br><small class="text-success fw-bold">(Billed ₹' + annualInr.toLocaleString('en-IN') + ' annually)</small>';
                }
            } else {
                symbolEl.textContent = '$';
                if (currentCycle === 'monthly') {
                    amountEl.textContent = monthlyUsd.toFixed(2);
                    periodEl.textContent = '/ month';
                } else {
                    const monthlyEquiv = (annualUsd / 12).toFixed(2);
                    amountEl.textContent = monthlyEquiv;
                    periodEl.innerHTML = '/ month <br><small class="text-success fw-bold">(Billed $' + annualUsd.toFixed(2) + ' annually)</small>';
                }
            }
        });
        updateCalculatorPrice();
    }

    // Dynamic Plan Dropdown update based on platform
    function updatePlanDropdown(platform) {
        const planSelect = document.getElementById('FormModel_Plan');
        if (!planSelect) return;

        const currentVal = planSelect.value;
        const options = [
            { text: '1 GB (₹250/month)', val: '1 GB (₹250/month)' },
            { text: '20 GB (₹500/month)', val: '20 GB (₹500/month)' },
            { text: 'Unlimited (₹2,500/month)', val: 'Unlimited (₹2,500/month)' },
            { text: 'Custom Enterprise Setup', val: 'Custom Enterprise Setup' }
        ];

        // Maintain selection if matched
        let matchFound = false;
        Array.from(planSelect.options).forEach(opt => {
            if (opt.value === currentVal) matchFound = true;
        });

        if (!matchFound && planSelect.options.length > 1) {
            planSelect.selectedIndex = 1; // Default to 20 GB
        }
    }

    // Plan Selection Buttons ("Configure & Deploy" / "Get Started")
    const selectPlanBtns = document.querySelectorAll('.select-plan-trigger');
    selectPlanBtns.forEach(btn => {
        btn.addEventListener('click', (e) => {
            e.preventDefault();
            const platform = btn.getAttribute('data-platform') || 'Linux';
            const planName = btn.getAttribute('data-plan') || '20 GB (₹500/month)';

            // Set platform switcher
            const targetPlatformBtn = document.querySelector(`.platform-btn[data-platform="${platform}"]`);
            targetPlatformBtn?.click();

            // Set form values
            const platformField = document.getElementById('FormModel_Platform');
            if (platformField) platformField.value = platform;

            const planField = document.getElementById('FormModel_Plan');
            if (planField) {
                // Find matching option or set value
                let matched = false;
                Array.from(planField.options).forEach(opt => {
                    if (opt.value.includes(planName) || planName.includes(opt.value)) {
                        planField.value = opt.value;
                        matched = true;
                    }
                });
                if (!matched) planField.value = planName;
            }

            // Scroll to form smoothly
            const formSection = document.getElementById('get-started');
            if (formSection) {
                formSection.scrollIntoView({ behavior: 'smooth' });
                const formCard = document.querySelector('.form-card');
                if (formCard) {
                    formCard.style.boxShadow = '0 0 35px rgba(37, 99, 235, 0.4)';
                    setTimeout(() => {
                        formCard.style.boxShadow = '';
                    }, 2000);
                }
            }
        });
    });

    // Cloud Resource Calculator Sliders
    const cpuSlider = document.getElementById('slider-cpu');
    const ramSlider = document.getElementById('slider-ram');
    const storageSlider = document.getElementById('slider-storage');

    const cpuValEl = document.getElementById('calc-cpu-val');
    const ramValEl = document.getElementById('calc-ram-val');
    const storageValEl = document.getElementById('calc-storage-val');

    const calcPriceEl = document.getElementById('calc-total-price');
    const calcSymbolEl = document.getElementById('calc-currency-symbol');
    const calcApplyBtn = document.getElementById('calc-apply-btn');

    function updateCalculatorPrice() {
        if (!cpuSlider || !ramSlider || !storageSlider) return;

        const cpu = parseInt(cpuSlider.value);
        const ram = parseInt(ramSlider.value);
        const storage = parseInt(storageSlider.value);

        if (cpuValEl) cpuValEl.textContent = cpu + ' vCPU' + (cpu > 1 ? 's' : '');
        if (ramValEl) ramValEl.textContent = ram + ' GB RAM';
        if (storageValEl) storageValEl.textContent = storage + ' GB NVMe';

        // Calculation formula: Base 250 + (CPU-1)*150 + (RAM-1)*100 + (Storage-10)*1.5
        let baseInr = 250;
        baseInr += (cpu - 1) * 200;
        baseInr += (ram - 1) * 80;
        baseInr += Math.max(0, storage - 10) * 1.8;
        baseInr = Math.round(baseInr / 50) * 50; // round to nearest 50

        if (currentCurrency === 'INR') {
            if (calcSymbolEl) calcSymbolEl.textContent = '₹';
            if (calcPriceEl) calcPriceEl.textContent = baseInr.toLocaleString('en-IN');
        } else {
            const usd = (baseInr * usdRate).toFixed(2);
            if (calcSymbolEl) calcSymbolEl.textContent = '$';
            if (calcPriceEl) calcPriceEl.textContent = usd;
        }
    }

    [cpuSlider, ramSlider, storageSlider].forEach(slider => {
        slider?.addEventListener('input', updateCalculatorPrice);
    });

    if (calcApplyBtn) {
        calcApplyBtn.addEventListener('click', (e) => {
            e.preventDefault();
            const cpu = cpuSlider?.value || '2';
            const ram = ramSlider?.value || '4';
            const storage = storageSlider?.value || '50';
            const specs = `Custom Cloud Spec: ${cpu} vCPU, ${ram} GB RAM, ${storage} GB NVMe Storage`;

            const planField = document.getElementById('FormModel_Plan');
            if (planField) planField.value = 'Custom Enterprise Setup';

            const msgField = document.getElementById('FormModel_Message');
            if (msgField) msgField.value = `I configured a custom server setup: ${specs}. Please provide a deployment quote.`;

            const formSection = document.getElementById('get-started');
            formSection?.scrollIntoView({ behavior: 'smooth' });
        });
    }

    // FAQ Search & Filter
    const faqSearchInput = document.getElementById('faqSearch');
    const faqCategoryPills = document.querySelectorAll('.faq-cat-pill');
    const faqItems = document.querySelectorAll('.faq-item-entry');

    function filterFaqs() {
        const query = faqSearchInput?.value.toLowerCase().trim() || '';
        const activeCategory = document.querySelector('.faq-cat-pill.active')?.getAttribute('data-category') || 'All';

        faqItems.forEach(item => {
            const cat = item.getAttribute('data-category') || '';
            const questionText = item.querySelector('.accordion-button')?.textContent.toLowerCase() || '';
            const answerText = item.querySelector('.accordion-body')?.textContent.toLowerCase() || '';

            const matchesCategory = (activeCategory === 'All' || cat === activeCategory);
            const matchesQuery = (!query || questionText.includes(query) || answerText.includes(query));

            if (matchesCategory && matchesQuery) {
                item.style.display = '';
                // Auto-expand if searching
                const collapseEl = item.querySelector('.accordion-collapse');
                const btnEl = item.querySelector('.accordion-button');
                if (query.length > 2 && collapseEl && btnEl) {
                    collapseEl.classList.add('show');
                    btnEl.classList.remove('collapsed');
                }
            } else {
                item.style.display = 'none';
            }
        });
    }

    faqSearchInput?.addEventListener('input', filterFaqs);

    faqCategoryPills.forEach(pill => {
        pill.addEventListener('click', () => {
            faqCategoryPills.forEach(p => p.classList.remove('active'));
            pill.classList.add('active');
            filterFaqs();
        });
    });

    // AJAX Submission Handling
    const getStartedForm = document.getElementById('getStartedForm');
    const submitBtn = document.getElementById('submitBtn');
    const submitFeedback = document.getElementById('submitFeedback');

    if (getStartedForm) {
        getStartedForm.addEventListener('submit', async (e) => {
            // If HTML5 valid, attempt AJAX for immediate user delight
            if (!getStartedForm.checkValidity()) {
                return; // let browser show standard validation
            }

            e.preventDefault();

            if (submitBtn) {
                submitBtn.disabled = true;
                submitBtn.innerHTML = '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span> Provisioning Request...';
            }

            const formData = new FormData(getStartedForm);

            try {
                const response = await fetch(getStartedForm.action, {
                    method: 'POST',
                    body: formData,
                    headers: {
                        'X-Requested-With': 'XMLHttpRequest'
                    }
                });

                const data = await response.json();

                if (data.success) {
                    if (submitFeedback) {
                        submitFeedback.innerHTML = `
                            <div class="alert alert-success d-flex align-items-start gap-3 p-4 rounded-4 shadow-sm">
                                <i class="bi bi-check-circle-fill text-success fs-2 flex-shrink-0"></i>
                                <div>
                                    <h5 class="alert-heading fw-bold mb-1">Request Received Successfully!</h5>
                                    <p class="mb-2">${data.message}</p>
                                    <div class="bg-white p-2 px-3 rounded-3 border d-inline-block text-dark fw-bold mb-2">
                                        <small class="text-muted text-uppercase d-block" style="font-size: 0.7rem;">Tracking Reference</small>
                                        <span class="text-primary font-monospace fs-5">${data.referenceNumber}</span>
                                    </div>
                                    <p class="small text-muted mb-0">A confirmation email has been dispatched with preliminary setup instructions and direct contact info for your assigned cloud engineer.</p>
                                </div>
                            </div>
                        `;
                        submitFeedback.scrollIntoView({ behavior: 'smooth' });
                    }
                    getStartedForm.reset();
                } else {
                    if (submitFeedback) {
                        submitFeedback.innerHTML = `
                            <div class="alert alert-danger d-flex align-items-center gap-3 p-3 rounded-3">
                                <i class="bi bi-exclamation-triangle-fill fs-3 text-danger flex-shrink-0"></i>
                                <div>
                                    <strong>Unable to submit:</strong> ${data.message || 'Please verify all fields.'}
                                </div>
                            </div>
                        `;
                    }
                }
            } catch (err) {
                // If AJAX fails, submit standard form
                console.warn('AJAX submit fallback:', err);
                getStartedForm.submit();
                return;
            } finally {
                if (submitBtn) {
                    submitBtn.disabled = false;
                    submitBtn.innerHTML = '<span>Get Started</span> <i class="bi bi-arrow-right"></i>';
                }
            }
        });
    }

    // Simulated live server activity in hero card
    const heroCpuBar = document.getElementById('hero-cpu-bar');
    const heroCpuText = document.getElementById('hero-cpu-text');
    const heroRamBar = document.getElementById('hero-ram-bar');
    const heroRamText = document.getElementById('hero-ram-text');

    if (heroCpuBar && heroCpuText) {
        setInterval(() => {
            const cpuVal = Math.floor(Math.random() * 14) + 12; // 12% - 25%
            const ramVal = Math.floor(Math.random() * 8) + 38;  // 38% - 45%
            heroCpuBar.style.width = cpuVal + '%';
            heroCpuText.textContent = cpuVal + '%';
            if (heroRamBar && heroRamText) {
                heroRamBar.style.width = ramVal + '%';
                heroRamText.textContent = ramVal + '%';
            }
        }, 3500);
    }
});
