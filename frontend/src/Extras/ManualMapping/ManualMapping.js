import PropTypes from 'prop-types';
import React, { Component } from 'react';
import LoadingIndicator from 'Components/Loading/LoadingIndicator';
import FieldSet from 'Components/FieldSet';
import Table from 'Components/Table/Table';
import TableBody from 'Components/Table/TableBody';
import TableRow from 'Components/Table/TableRow';
import TableRowCell from 'Components/Table/Cells/TableRowCell';
import styles from './ManualMapping.css';

const columns = [
  {
    className: styles.status,
    name: 'tvdbId',
    label: 'Tvdb Id',
    isVisible: true
  },
  {
    name: 'manualMappingTitle',
    label: 'Manual Mapping Title',
    isVisible: true
  }
];

class ManualMapping extends Component {

  //
  // Render

  render() {
    const {
      isFetching,
      items
    } = this.props;

    return (
      <FieldSet legend="Manual Mapping">
        {
          isFetching &&
            <LoadingIndicator />
        }

        {
          !isFetching &&
            <Table columns={columns}>
              <TableBody>
                {
                  items.map((item) => {

                    return (
                      <TableRow key={`${item.tvdbId}-${item.manualMappingTitle}`}>
                        <TableRowCell>
                        {
                            item.tvdbId
                        }
                        </TableRowCell>
                        <TableRowCell>
                        {
                            item.manualMappingTitle
                        }
                        </TableRowCell>
                      </TableRow>
                    );
                  })
                }
              </TableBody>
            </Table>
        }
      </FieldSet>
    );
  }

}

ManualMapping.propTypes = {
  isFetching: PropTypes.bool.isRequired,
  items: PropTypes.array.isRequired
};

export default ManualMapping;
