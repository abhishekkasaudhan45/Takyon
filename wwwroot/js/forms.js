/**
 * Takyon Networks Limited - Client-side form handling and validation
 * Prototype-only notice: No backend submission, persistence, or email dispatch.
 */
document.addEventListener('DOMContentLoaded', function () {
  // Contact Form Handling
  const contactForm = document.getElementById('takyonContactForm');
  const contactSuccessNotice = document.getElementById('contactSuccessNotice');

  if (contactForm && contactSuccessNotice) {
    contactForm.addEventListener('submit', function (e) {
      e.preventDefault();

      let isValid = true;
      let firstInvalidField = null;

      const nameInput = document.getElementById('fullName');
      const emailInput = document.getElementById('email');
      const messageInput = document.getElementById('message');

      // Helper function
      function validateField(input, condition) {
        if (!condition) {
          input.classList.add('is-invalid');
          input.classList.remove('is-valid');
          isValid = false;
          if (!firstInvalidField) firstInvalidField = input;
        } else {
          input.classList.remove('is-invalid');
          input.classList.add('is-valid');
        }
      }

      // Validate Full Name
      validateField(nameInput, nameInput.value.trim().length >= 2);

      // Validate Email
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      validateField(emailInput, emailRegex.test(emailInput.value.trim()));

      // Validate Message
      validateField(messageInput, messageInput.value.trim().length >= 10);

      if (!isValid) {
        if (firstInvalidField) {
          firstInvalidField.focus();
        }
        contactSuccessNotice.classList.add('d-none');
        return;
      }

      // If valid, display the honest prototype demo message
      contactSuccessNotice.classList.remove('d-none');
      contactSuccessNotice.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
      contactForm.reset();

      // Clear valid indicators after reset
      [nameInput, emailInput, messageInput].forEach(field => {
        field.classList.remove('is-valid');
        field.classList.remove('is-invalid');
      });
    });

    // Clear error states on input
    contactForm.querySelectorAll('input, textarea, select').forEach(field => {
      field.addEventListener('input', function () {
        if (this.classList.contains('is-invalid')) {
          this.classList.remove('is-invalid');
        }
      });
    });
  }

  // Newsletter Form Handling
  const newsletterForm = document.getElementById('newsletterForm');
  const newsletterSuccess = document.getElementById('newsletterSuccess');

  if (newsletterForm && newsletterSuccess) {
    newsletterForm.addEventListener('submit', function (e) {
      e.preventDefault();

      const emailField = document.getElementById('newsletterEmail');
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

      if (!emailField || !emailRegex.test(emailField.value.trim())) {
        if (emailField) {
          emailField.classList.add('is-invalid');
          emailField.focus();
        }
        newsletterSuccess.classList.add('d-none');
        return;
      }

      emailField.classList.remove('is-invalid');
      newsletterSuccess.classList.remove('d-none');
      newsletterForm.reset();
    });
  }
});
