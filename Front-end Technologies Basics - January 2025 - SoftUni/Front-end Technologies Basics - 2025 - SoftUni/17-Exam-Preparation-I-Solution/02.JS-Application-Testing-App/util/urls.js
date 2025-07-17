function getLoginUrl(){
    return 'http://localhost:3030/users/login';
}

function getRegisterUrl(){
    return 'http://localhost:3030/users/register';
}

function getLogoutUrl(){
    return 'http://localhost:3030/users/logout';
}

function getBaseUrl(){
    return 'http://localhost:3030';
}

function getItemsUrl(){
    return `${getBaseUrl()}/data/albums`; //must be change
}


function encodeURL(url){
    return encodeURIComponent(url);
}

export const url ={
    getLoginUrl,
    getRegisterUrl,
    getLogoutUrl,
    getBaseUrl,
    getItemsUrl,
    encodeURL
}