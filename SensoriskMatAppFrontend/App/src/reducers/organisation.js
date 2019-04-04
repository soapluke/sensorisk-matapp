const organisationDefaultState = [];

export default (state = organisationDefaultState, action) => {
    switch (action.type) {
        case 'FETCH_ORGANISATION':
            return action.organisation;
        default:
            return state;
    }
};