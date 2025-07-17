function getUserObj(){
    return JSON.parse(sessionStorage.getItem('app-user'));
}

function getToken(){
    if(getUserObj()){
        return getUserObj().accessToken;
    }
    return null;
}

export const userInfo = {
    getUserObj,
    getToken
}