import PropTypes from 'prop-types';
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { createSelector } from 'reselect';
import { fetchManualMappings } from 'Store/Actions/extraActions';
import ManualMapping from './ManualMapping';

function createMapStateToProps() {
  return createSelector(
    (state) => state.extras.manualMapping,
    (manualMapping) => {
      const {
        isFetching,
        items
      } = manualMapping;

      return {
        isFetching,
        items
      };
    }
  );
}

const mapDispatchToProps = {
    fetchManualMappings
};

class ManualMappingConnector extends Component {

  //
  // Lifecycle

  componentDidMount() {
    this.props.fetchManualMappings();
  }

  //
  // Render

  render() {
    return (
      <ManualMapping
        {...this.props}
      />
    );
  }
}

ManualMappingConnector.propTypes = {
    fetchManualMappings: PropTypes.func.isRequired
};

export default connect(createMapStateToProps, mapDispatchToProps)(ManualMappingConnector);
