export const fetchWithoutToken = (endpoint, data, method = 'GET') => {
    const url = `http://localhost:5063/${endpoint}`;

    if (method === 'GET') {
        return fetch(url);
    }
    else {
        return fetch(url, {
            method,
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(data)
        });
    }
}