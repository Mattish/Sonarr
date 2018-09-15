import { createThunk, handleThunks } from 'Store/thunks';
import createFetchHandler from './Creators/createFetchHandler';
import createHandleActions from './Creators/createHandleActions';
//
// Variables

export const section = 'extras';
//
// State

export const defaultState = {
    manualMapping: {
        isFetching: false,
        isPopulated: false,
        error: null,
        items: []
    }
};

//
// Actions Types

export const FETCH_MANUALMAPPINGS = 'extras/manualmappings/fetchManualMappings';

//
// Action Creators

export const fetchManualMappings = createThunk(FETCH_MANUALMAPPINGS);

//
// Action Handlers

export const actionHandlers = handleThunks({
    [FETCH_MANUALMAPPINGS]: createFetchHandler('extras.manualMapping', '/extras/manualmapping'),
});

//
// Reducers

export const reducers = createHandleActions({

}, defaultState, section);