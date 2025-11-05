$(document).ready(function () {
    var toastElement = $('#myToast');
    toastElement.toast('show'); // Show toast automatically
    setTimeout(function () {
        toastElement.fadeOut(); // Hide the toast after 5 seconds
    }, 5000);
});


document.addEventListener("DOMContentLoaded", function () {
    if (window.chartData) {
        // ================= BAR CHART =================
        var ctx1 = document.getElementById('hoursChart').getContext('2d');
        new Chart(ctx1, {
            type: 'bar',
            data: {
                labels: window.chartData.hours.labels,
                datasets: [{
                    label: 'Hours per Employee',
                    data: window.chartData.hours.values,
                    backgroundColor: [
                        'rgba(54, 162, 235, 0.7)',
                        'rgba(255, 99, 132, 0.7)',
                        'rgba(255, 206, 86, 0.7)',
                        'rgba(75, 192, 192, 0.7)',
                        'rgba(153, 102, 255, 0.7)',
                        'rgba(255, 159, 64, 0.7)'
                    ],
                    borderColor: '#fff',
                    borderWidth: 2,
                    borderRadius: 6
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        backgroundColor: '#333',
                        titleColor: '#fff',
                        bodyColor: '#fff',
                        borderWidth: 1,
                        borderColor: '#555'
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: { stepSize: 5 }
                    }
                }
            }
        });

        // ================= LINE CHART =================
        var ctx2 = document.getElementById('dailyTrendChart').getContext('2d');
        new Chart(ctx2, {
            type: 'line',
            data: {
                labels: window.chartData.dailyTrend.labels,
                datasets: [{
                    label: 'Completed Tasks',
                    data: window.chartData.dailyTrend.values,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    pointBackgroundColor: '#fff',
                    pointBorderColor: 'rgba(75, 192, 192, 1)',
                    pointHoverRadius: 6,
                    tension: 0.4,
                    fill: true
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        labels: { color: '#333', font: { size: 14 } }
                    },
                    tooltip: {
                        backgroundColor: '#444',
                        titleColor: '#fff',
                        bodyColor: '#eee',
                        borderWidth: 1,
                        borderColor: '#222'
                    }
                },
                scales: {
                    x: {
                        ticks: { color: '#555' }
                    },
                    y: {
                        beginAtZero: true,
                        ticks: { color: '#555', stepSize: 1 }
                    }
                }
            }
        });
    }
});
