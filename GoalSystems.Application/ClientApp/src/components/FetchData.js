import React, { Component } from 'react';
import { UncontrolledAlert } from 'reactstrap';

import { baseUrl } from '../apiConfig'

export class FetchData extends Component {
  

  constructor(props) {
    super(props);
      this.state = { items: [], loading: true, notifications: [] };

      this.removeItem = this.removeItem.bind(this);
    }

    async removeItem(itemName) {
        const confirmed = window.confirm(`Are you sure you want to delete the item ${itemName}?`)
        
        if (confirmed) {
            const response = await fetch(`${baseUrl}/delete?itemName=${itemName}`, {
                method: 'DELETE'
            })
            if (response.ok) {

                let actualNotifications = this.state.notifications

                actualNotifications.push(<UncontrolledAlert color="danger" key={itemName}>
                    Item <strong>{itemName}</strong> has been removed.
                </UncontrolledAlert>)

                this.setState({
                    notifications: actualNotifications
                })

                await this.populateItemsData()
            }
        }
    }

  componentDidMount() {
    this.populateItemsData();
  }

  

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : <div>
            {this.state.notifications.map((notification) => notification)}

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Expiration Date</th>
                        <th>Name</th>
                        <th>Type</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.items.map((item, i) => {

                        const now = Date.now()
                        const expirationDate = new Date(item.expirationDate)

                        return <tr key={i}>
                            <td>{expirationDate.toDateString()} {(now > expirationDate && <span className="badge bg-warning">expired</span>)}</td>
                            <td>{item.name}</td>
                            <td>{item.type}</td>
                            <td>  <button className="btn btn-danger" onClick={() => this.removeItem(item.name)} >Remove</button>  </td>
                        </tr>
                    }
                    )}
                </tbody>
            </table>
        </div>

    return (
      <div>
        <h1 id="tabelLabel" >Items</h1>
        
        {contents}
      </div>
    );
  }

    async populateItemsData() {
        const response = await fetch(baseUrl);
    const data = await response.json();
    this.setState({ items: data, loading: false });
    }

    
}
