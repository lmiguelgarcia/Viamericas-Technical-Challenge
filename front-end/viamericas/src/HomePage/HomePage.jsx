import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import './styles.css';
import { agencyActions } from '../_actions';

class HomePage extends React.Component {
    componentDidMount() {        
        this.props.dispatch(agencyActions.getAllAgencies());

        this.colorStatus.bind(this);
    }

    colorStatus(status) {
        if (status === 'Closed') {
            return 'agency-closed';
        } else {
            return '';
        }
    }

    render() {
        const {  agencies } = this.props;
        return (
            <div>
                <h1>Viamericas Agencies</h1>
                {agencies.loading && <em>Loading agencies...</em>}
                {agencies.error && <span className="text-danger">ERROR: {agencies.error}</span>}
                {agencies.items &&
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th onClick={() => this.sortBy('id')}>Id</th>
                                <th onClick={() => this.sortBy('name')}>Name</th>
                                <th onClick={() => this.sortBy('status')}>Status</th>
                                <th onClick={() => this.sortBy('city')}>City</th>
                            </tr>
                        </thead>
                        <tbody>
                            {agencies.items.map((agency, index) => {
                                return (
                                    <tr key={index} className={this.colorStatus(agency.status)}>
                                        <td>{index + 1}</td>
                                        <td>{agency.id}</td>
                                        <td>{agency.name}</td>
                                        <td>{agency.status}</td>
                                        <td>{agency.city}</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                }
                <br></br>
                <p>
                    <Link to="/login">Logout</Link>
                </p>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { agencies } = state;
    return {
        agencies
    };
}

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };