# Blockchain and Security Coursework Assignment

This repository contains a C# Windows Forms coursework application that demonstrates core blockchain and security concepts. The app lets a user create wallets, sign and validate transactions, mine blocks, inspect the blockchain, and compare single-threaded and multi-threaded proof-of-work mining.

## Features

- Windows Forms interface for interacting with the blockchain.
- Wallet generation using ECDSA P-256 key pairs.
- Transaction creation with digital signatures and sender balance checks.
- SHA-256 block hashing with proof-of-work difficulty validation.
- Merkle root calculation for block transaction integrity.
- Genesis block creation and linked block validation.
- Mining rewards and transaction fee handling.
- Adjustable mining difficulty based on recent block times.
- Single-threaded and multi-threaded mining modes.
- Transaction selection modes:
  - Altruistic: oldest transactions first.
  - Greedy: highest-fee transactions first.
  - Random: random pending transactions.
  - Address: address-based ordering.
- Blockchain validation for hashes, Merkle roots, block links, and transaction signatures.

## Project Structure

```text
BlockchainAssignment.sln
BlockchainAssignment/
  Block.cs                     Block model, hashing, mining, rewards, Merkle roots
  Blockchain.cs                Chain state, transaction pool, validation, difficulty adjustment
  BlockchainApp.cs             Windows Forms event handlers and UI workflow
  BlockchainApp.Designer.cs    Windows Forms designer-generated layout
  Transaction.cs               Transaction model, hashing, signatures
  Wallet/Wallet.cs             Wallet key generation and ECDSA signature helpers
  HashCode/HashTools.cs        SHA-256 hash helper utilities
```

## Requirements

- Windows
- Visual Studio 2019 or newer, or Visual Studio Build Tools
- .NET Framework 4.7.2 targeting pack

The project is a Windows Forms application and depends on Windows-only cryptography APIs such as `System.Security.Cryptography.CngKey`.

## Getting Started

1. Open `BlockchainAssignment.sln` in Visual Studio.
2. Restore/build the solution.
3. Run the `BlockchainAssignment` project.

To build from a Developer Command Prompt:

```powershell
msbuild BlockchainAssignment.sln /p:Configuration=Debug
```

## Using the Application

1. Generate a wallet to create a public/private key pair.
2. Mine an initial block to receive mining rewards.
3. Create transactions by entering a receiver address, amount, and fee.
4. Select a mining strategy and mine a block to include pending transactions.
5. Use the read, balance, and validation controls to inspect chain state.
6. Toggle multi-threaded mining to compare mining performance.

## Notes

This is an educational coursework project. It demonstrates blockchain data structures and security mechanisms locally; it is not intended to be used as a production cryptocurrency or networked blockchain implementation.
