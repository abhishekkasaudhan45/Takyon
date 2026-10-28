/**
 * Takyon Networks Limited - Primary Site JavaScript
 * Lightweight, accessible interactions with no unnecessary frameworks.
 */
document.addEventListener('DOMContentLoaded', function () {
  // Collapse mobile navigation menu when a link is clicked
  const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
  const navbarCollapse = document.getElementById('takyonNavContent');

  if (navbarCollapse && window.bootstrap) {
    const bsCollapse = bootstrap.Collapse.getInstance(navbarCollapse) || new bootstrap.Collapse(navbarCollapse, { toggle: false });
    navLinks.forEach(function (link) {
      link.addEventListener('click', function () {
        if (navbarCollapse.classList.contains('show')) {
          bsCollapse.hide();
        }
      });
    });
  }
});
