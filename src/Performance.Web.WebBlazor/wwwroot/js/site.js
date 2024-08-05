window.saveTokenToLocalStorage = (token) => {
    if (token) {
        localStorage.setItem('authToken', token);
    }
};
