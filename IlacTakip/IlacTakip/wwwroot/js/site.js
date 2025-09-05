// İlaç Takip Sistemi - Custom JavaScript

// Sayfa yüklendiğinde çalışacak fonksiyonlar
document.addEventListener('DOMContentLoaded', function() {
    console.log('İlaç Takip Sistemi yüklendi');
    
    // Bootstrap tooltip'lerini etkinleştir
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
    
    // Form validasyonları
    setupFormValidation();
    
    // Arama fonksiyonalitesi
    setupSearchFunctionality();
});

// Form validasyonu
function setupFormValidation() {
    const forms = document.querySelectorAll('.needs-validation');
    
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });
}

// Arama fonksiyonalitesi
function setupSearchFunctionality() {
    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            const cards = document.querySelectorAll('.card');
            
            cards.forEach(card => {
                const text = card.textContent.toLowerCase();
                if (text.includes(searchTerm)) {
                    card.style.display = 'block';
                } else {
                    card.style.display = 'none';
                }
            });
        });
    }
}

// Sipariş durumu güncelleme
function updateOrderStatus(orderId, status) {
    if (confirm('Sipariş durumunu güncellemek istediğinizden emin misiniz?')) {
        // AJAX isteği burada yapılacak
        console.log('Sipariş durumu güncelleniyor:', orderId, status);
    }
}

// İlaç silme onayı
function confirmDelete(drugId, drugName) {
    if (confirm(`"${drugName}" ilacını silmek istediğinizden emin misiniz?`)) {
        // Silme işlemi burada yapılacak
        console.log('İlaç siliniyor:', drugId);
    }
}

// Fiyat formatı
function formatPrice(price) {
    return new Intl.NumberFormat('tr-TR', {
        style: 'currency',
        currency: 'TRY'
    }).format(price);
}

// Tarih formatı
function formatDate(date) {
    return new Date(date).toLocaleDateString('tr-TR');
}
