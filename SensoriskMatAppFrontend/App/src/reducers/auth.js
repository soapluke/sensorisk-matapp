const authDefaultState = [];

export default (state = authDefaultState, action) => {
    switch (action.type) {
        case 'LOGIN':
            return {
                id: action.id
            };
        case 'LOGOUT':
            return {};
        default:
            return state;
    }
};